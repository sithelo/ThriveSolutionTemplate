// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Clarity;
using Transaction.Domain.Cards;
using static Transaction.Domain.Events.TraderEvents;
using static Transaction.Domain.DomainServices.Services;

namespace Transaction.Domain;

public class Trader : Aggregate<TraderState> {
    public async Task CreateTrader(
        TraderId       traderId,
        ThriveId       thriveId,
        string         profileNumber,
        DateTimeOffset createdAt,
        IsNewTrader    isNewTrader
    ) {
        EnsureDoesntExist();
        await EnsureNewTrader(thriveId, profileNumber, isNewTrader);
        Apply(
            new V1.TraderCreated(traderId, profileNumber, createdAt));
    }

    public async Task LinkCard(
        string         cardNumber,
        string         cardIdentifier,
        string         cvv,
        DateTimeOffset linkedAt
        ) {
        EnsureExists();
        if (State.HasCardBeenLinked(cardNumber)) return;

        Apply(
            new V1.CardLinked(cardNumber, cardIdentifier, cvv, new CardStatus("Active"), linkedAt));
        
        // If another event, add it here

    }
    private async Task EnsureNewTrader(ThriveId thriveId, string profileNumber, IsNewTrader isNewTrader) {
        var newTrader = await isNewTrader(thriveId, profileNumber);
        if (newTrader) throw new DomainException("ThriveId not new");
    }
}