// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace Transaction.Domain.Cards; 

public record CardStatus{
    
    public string CardReason { get; internal init; }
    private static readonly string[] SupportedStatuses = { "Blocked", "UnBlocked", "Active", "RaiseDispute", "TopUp", "RequestStatement" };
    
    internal CardStatus() { }

    public CardStatus(string cardReason) {
        if (!SupportedStatuses.Contains(cardReason)) throw new ArgumentOutOfRangeException(nameof(cardReason),$"Unsupported reason: {cardReason}");

        CardReason = cardReason;
    }
}