// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardManagement.Domain.Entities;
using ThriveShared;

namespace CardManagement.Domain.Events;

public class ActivatedCardEvent : DomainEventBase {
    public ActivatedCardEvent(Trader trader) {
        TraderActivated = trader;
    }

    public Guid   Id              { get; private set; } = Guid.NewGuid();
    public Trader TraderActivated { get; private set; }
}