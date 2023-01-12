// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using ThriveShared;


namespace CardTransaction.Domain.Events;

public class CardUpdatedEvent : DomainEventBase {
    public CardUpdatedEvent(Card card) {
        CardUpdated = card;
    }

    public Guid Id          { get; private set; } = Guid.NewGuid();
    public Card CardUpdated { get; private set; }
}