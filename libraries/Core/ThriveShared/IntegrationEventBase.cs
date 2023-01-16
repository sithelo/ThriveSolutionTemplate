// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using MediatR;

namespace ThriveShared;

public abstract class IntegrationEventBase : INotification {
    public DateTimeOffset DateOccurred { get; protected set; } = DateTime.UtcNow;
    string                EventType    { get; }
}