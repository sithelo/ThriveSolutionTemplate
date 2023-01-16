// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using System.Collections.Concurrent;
using Azure.Messaging.ServiceBus;
using ThriveAzureServiceBus.Interfaces;


namespace ThriveAzureServiceBus;

public class AzureServiceBusFactory : IMessageBusFactory {
    private readonly object _lockObject = new();

    private readonly ConcurrentDictionary<string, ServiceBusClient> _clients = new();

    private readonly ConcurrentDictionary<string, ServiceBusSender> _senders = new();

    public IMessageBus GetClient(string connectionString, string senderName) {
        var key = $"{connectionString}-{senderName}";

        if (_senders.ContainsKey(key) && !_senders[key].IsClosed) {
            return AzureServiceBusPublisher.Create(_senders[key]);
        }

        var client = GetServiceBusClient(connectionString);

        lock (_lockObject) {
            if (_senders.ContainsKey(key) && _senders[key].IsClosed) {
                if (_senders[key].IsClosed) {
                    _senders[key].DisposeAsync().GetAwaiter().GetResult();
                }

                return AzureServiceBusPublisher.Create(_senders[key]);
            }

            var sender = client.CreateSender(senderName);

            _senders[key] = sender;
        }

        return AzureServiceBusPublisher.Create(_senders[key]);
    }
    protected virtual ServiceBusClient GetServiceBusClient(string connectionString)
    {
        var key = $"{connectionString}";

        lock (_lockObject)
        {
            if (!ClientDoesntExistOrIsClosed(connectionString)) return _clients[key];

            var client = new ServiceBusClient(connectionString, new ServiceBusClientOptions
            {
                TransportType = ServiceBusTransportType.AmqpTcp,
                RetryOptions = new ServiceBusRetryOptions {
                    Delay      = TimeSpan.FromSeconds(10),
                    MaxDelay   = TimeSpan.FromSeconds(30),
                    Mode       = ServiceBusRetryMode.Exponential,
                    MaxRetries = 3, 
                }
            });

            _clients[key] = client;

            return _clients[key];
        }
    }

    private bool ClientDoesntExistOrIsClosed(string connectionString)
    {
        return !_clients.ContainsKey(connectionString) || _clients[connectionString].IsClosed;
    }
}