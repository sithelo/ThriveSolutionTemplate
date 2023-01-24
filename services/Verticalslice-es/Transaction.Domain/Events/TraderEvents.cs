// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Clarity;
using Transaction.Domain.Cards;

namespace Transaction.Domain.Events;

public static class TraderEvents {
    public static class V1 {
        [EventType("V1.TraderCreated")]
        public record TraderCreated(
            string         ThriveId,
            string         ProfileNumber,
            DateTimeOffset CreatedAt
        );

        [EventType("V1.CardLinked")]
        public record CardLinked(
            string         CardNumber,
            string         CardIdentifier,
            string         Cvv,
            CardStatus          cardStatus,
            DateTimeOffset LinkedAt
        );
    }
}