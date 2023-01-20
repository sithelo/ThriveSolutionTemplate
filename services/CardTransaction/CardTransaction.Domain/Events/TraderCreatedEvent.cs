// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using ThriveShared;

namespace CardTransaction.Domain.Events; 

public class TraderCreatedEvent : DomainEventBase {
    public TraderCreatedEvent(Trader trader) {
        TraderCreated = trader;
    }

    public Guid   Id             { get; private set; } = Guid.NewGuid();
    public Trader TraderCreated { get; private set; }
}