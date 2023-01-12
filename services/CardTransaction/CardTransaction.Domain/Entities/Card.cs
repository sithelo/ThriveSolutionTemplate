// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.GuardClauses;
using CardTransaction.Domain.Events;
using CardTransaction.Domain.ValueObjects;
using ThriveShared;

namespace CardTransaction.Domain.Entities;

public class Card : EntityBase<Guid> {
    public Guid       TraderId       { get; private set; }
    public string     CardNumber     { get; private set; }
    public string     CardIdentifier { get; private set; }
    public string     ProfileNumber  { get; private set; }
    public CardStatus CardStatus     { get; private set; }
    
    public void UpdateCardStatus(CardStatus newStatus)
    {
        Guard.Against.NullOrEmpty(newStatus.CardReason, nameof(newStatus));
        if (newStatus.CardReason == CardStatus.CardReason) return;

        CardStatus = newStatus;

        var cardUpdatedEvent = new CardUpdatedEvent(this);
        base.RegisterDomainEvent(cardUpdatedEvent);
    }
}