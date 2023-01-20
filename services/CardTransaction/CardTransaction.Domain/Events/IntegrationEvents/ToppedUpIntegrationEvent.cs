// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using ThriveShared;

namespace CardTransaction.Domain.Events.IntegrationEvents; 

public class ToppedUpIntegrationEvent : IntegrationEventBase {
    public ToppedUpIntegrationEvent() {
        DateOccurred = DateTimeOffset.Now; 
    }
    public string ThriveId { get; set; }
    public float CardBalance { get; set; }
    public string EventType => nameof(ToppedUpIntegrationEvent);
}