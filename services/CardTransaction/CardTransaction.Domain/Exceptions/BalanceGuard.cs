// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.GuardClauses;

namespace CardTransaction.Domain.Exceptions; 

public static class TraderGuard {
    public static void Kycd(this IGuardClause guardClause, bool input, string parameterName) {
        if(!input) throw new ArgumentException("Should be KYCed", parameterName);
    }
    
}