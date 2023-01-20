// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace CardTransaction.Domain.ValueObjects; 

public record Money {
    public float  Amount   { get; internal init; }
    public string Currency { get; internal init; }

    private static readonly string[] SupportedCurrencies = { "ZAR" };

    internal Money() {
    }

    public Money(float amount, string currency) {
        if (!SupportedCurrencies.Contains(currency)) throw new ArgumentOutOfRangeException(nameof(currency),$"Unsupported currency: {currency}");

        Amount   = amount;
        Currency = currency;
    }
    public bool IsSameCurrency(Money another) => Currency == another.Currency;

    public static Money operator -(Money one, Money another) {
        SameCurrencyError(one, another);
        return new Money(one.Amount - another.Amount, one.Currency);
    }

   

    public static Money operator +(Money one, Money another) {
        SameCurrencyError(one, another);
        return new Money(one.Amount + another.Amount, one.Currency);
    }

    private static void SameCurrencyError(Money one, Money another) {
        if (!one.IsSameCurrency(another)) throw new Exception("Cannot operate on different currencies");
    }
    public static implicit operator double(Money money) => money.Amount;
};