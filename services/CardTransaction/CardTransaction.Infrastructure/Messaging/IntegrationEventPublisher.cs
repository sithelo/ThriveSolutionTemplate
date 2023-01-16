// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.


using ThriveAzureServiceBus.Interfaces;
using ThriveShared.Interfaces;

namespace CardTransaction.Infrastructure.Messaging; 

public class IntegrationEventPublisher : IMessagePublisher {
    private readonly IMessageBusFactory _messageBusFactory;
    public IntegrationEventPublisher(IMessageBusFactory messageBusFactory) {
        _messageBusFactory = messageBusFactory;
    }
    public async Task Publish<T>(T message, string subject, string correlationId) {
        var client = _messageBusFactory.GetClient(
            "",
            "");

        await client.PublishMessageAsync(message, subject, correlationId);
    }
}