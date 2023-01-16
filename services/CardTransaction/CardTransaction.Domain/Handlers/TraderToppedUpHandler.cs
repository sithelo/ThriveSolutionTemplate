// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Events;
using CardTransaction.Domain.Events.IntegrationEvents;
using MediatR;
using ThriveShared.Interfaces;

namespace CardTransaction.Domain.Handlers; 

public class TraderToppedUpHandler : INotificationHandler<TraderToppedUpEvent> {
    private readonly IMessagePublisher _messagePublisher;

    public TraderToppedUpHandler(IMessagePublisher messagePublisher) {
        _messagePublisher = messagePublisher;
    }

    public async Task Handle(TraderToppedUpEvent notification, CancellationToken cancellationToken) {
        var newMessage = new ToppedUpIntegrationEvent {
            ThriveId    = "3456723",
            CardBalance = 12345
        };

        await _messagePublisher.Publish(newMessage, nameof(ToppedUpIntegrationEvent), Guid.NewGuid().ToString());
    }
}