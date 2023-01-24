// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using System.Collections.Immutable;
using Clarity;
using Transaction.Domain.Cards;
using Transaction.Domain.Events;

namespace Transaction.Domain;

public record TraderState : State<TraderState> {
    public ThriveId     ThriveId     { get; private set; }
    public Profile      Profile      { get; private set; }
    public KycStatus    KYC          { get; private set; }
    public ThriveWallet ThriveWallet { get; private set; }

    public ImmutableList<Card> Cards { get; init; } = ImmutableList<Card>.Empty;

    internal bool HasCardBeenLinked(string cardNumber) =>
        Cards.Any(x => x.CardNumber == cardNumber);


    public TraderState() {
        On<TraderEvents.V1.TraderCreated>(HandleTraderCreated);
        // On<TraderEvents.V1.CardLinked>(HandleCardLinked);
    }

    // private static TraderState HandleCardLinked(TraderState state, TraderEvents.V1.CardLinked e) => state with {
    //     Cards = state.Cards.Add(new Card(Guid.NewGuid(),
    //         new Money { Amount = 0, Currency = "ZAR" },
    //         e.CardNumber,
    //         e.CardIdentifier,
    //         e.CardIdentifier,
    //         e.Cvv,
    //         new CardStatus { CardReason = e.cardStatus.CardReason },
    //         null))
    // };

private static TraderState HandleTraderCreated(TraderState state, TraderEvents.V1.TraderCreated e)
    => state with {
        ThriveId = new ThriveId(e.ThriveId),
        Profile = new Profile()
    };

}

public record ThriveWallet { }

public record KycStatus { }

public record Profile { }