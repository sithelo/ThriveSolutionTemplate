// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using System.Collections.Immutable;
using Clarity;

namespace Transaction.Domain.Cards;

public record CardState : State<CardState> {
    public string                         ThriveId         { get; init; }
    public Money                          Amount           { get; init; }
    public string                         Currency         { get; init; }
    public string                         CardNumber       { get; init; }
    public string                         CardIdentifier   { get; init; }
    public string                         Cvv              { get; init; }
    public CardStatus                     CardStatus       { get; init; }
    public ImmutableList<CardTransaction> CardTransactions { get; init; } = ImmutableList<CardTransaction>.Empty;
};