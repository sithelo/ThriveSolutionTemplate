// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.


using System.Text;
using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;
using ThriveAzureServiceBus.Interfaces;

namespace ThriveAzureServiceBus;

public class AzureServiceBusPublisher : IMessageBus {
    private readonly ServiceBusSender _serviceBusSender;

    public AzureServiceBusPublisher(ServiceBusSender serviceBusSender) {
        _serviceBusSender = serviceBusSender;
    }

    public async Task PublishMessageAsync<T>(T message, string subject, string correlationId) {
        var jsonString = JsonConvert.SerializeObject(message);
        var serviceBusMessage = new ServiceBusMessage(Encoding.UTF8.GetBytes(jsonString)) {
            Subject       = subject,
            CorrelationId = correlationId
        };

        await _serviceBusSender.SendMessageAsync(serviceBusMessage);
    }

    internal static IMessageBus Create(ServiceBusSender sender) {
        return new AzureServiceBusPublisher(sender);
    }
}