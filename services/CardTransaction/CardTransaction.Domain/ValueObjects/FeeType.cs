// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace CardTransaction.Domain.ValueObjects;

public record FeeType {
    public                  string   Type      { get; private set; }
    public                  string   Reference { get; private set; }
    private static readonly string[] SupportedFeeType = { "Fees" };
    private static readonly string[] SupportedFeeReferences = { "Transfer to Thrive balance" };
    
    public FeeType(string type, string reference) {
        if (!SupportedFeeType.Contains(type)) throw new ArgumentOutOfRangeException(nameof(type),$"Unsupported fee: {type}");
        if (!SupportedFeeType.Contains(reference)) throw new ArgumentOutOfRangeException(nameof(reference),$"Unsupported fee: {reference}");

        Type   = type;
        Reference = reference;
    }
};