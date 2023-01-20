// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using ThriveShared;

namespace CardTransaction.Domain.Events;

public class TraderTransferredEvent : DomainEventBase {
    public TraderTransferredEvent(Trader trader) {
        TraderTrasferred = trader;
    }

    public Guid   Id               { get; private set; } = Guid.NewGuid();
    public Trader TraderTrasferred { get; private set; }
}