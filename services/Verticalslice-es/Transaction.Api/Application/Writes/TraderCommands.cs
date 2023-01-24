// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace Transaction.Api.Application.Writes; 

public static class TraderCommands {
    public record CreateTrader {
        public string ThriveId      { get; init; }
        public string ProfileNumber { get; init; }
    }
}