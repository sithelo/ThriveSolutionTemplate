// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.


using Ardalis.GuardClauses;
using CardTransaction.Domain.Events;
using CardTransaction.Domain.Exceptions;
using CardTransaction.Domain.ValueObjects;
using ThriveShared;
using ThriveShared.Interfaces;

namespace CardTransaction.Domain.Entities;

public class Trader : EntityBase<Guid>, IAggregateRoot {
    public           string            ThriveId       { get; private set; }
    public           bool              KYC            { get; private set; }
    public           string            Currency       { get; private set; }
    public           Money             CardBalance    { get; private set; }
    public           Money             WalletBalance  { get; private set; }
    public           Money             AdvanceBalance { get; private set; }
    public           Money             Fee            { get; private set; }
    private readonly List<Card>        _cards = new List<Card>();
    public           IEnumerable<Card> Cards => _cards.AsReadOnly();

    
    public void TopUpCardBalance(Money topUpAmount) {
        Guard.Against.Kycd(KYC, nameof(KYC));
        Guard.Against.NegativeOrZero(topUpAmount, nameof(topUpAmount));
        Guard.Against.OutOfRange(topUpAmount.Amount, nameof(topUpAmount), topUpAmount.Amount, WalletBalance.Amount);

        CardBalance   += topUpAmount;
        WalletBalance -= topUpAmount;
        var traderToppedUpEvent = new TraderToppedUpEvent(this);
        base.RegisterDomainEvent(traderToppedUpEvent);
    }

    public void TransferCardBalance(Money transferAmount) {
        Guard.Against.Kycd(KYC, nameof(KYC));
        Guard.Against.NegativeOrZero(transferAmount, nameof(transferAmount));
        Guard.Against.OutOfRange(transferAmount.Amount, nameof(transferAmount), transferAmount.Amount, WalletBalance.Amount);

        CardBalance   -= transferAmount;
        WalletBalance += transferAmount;
        var traderTransferredEvent = new TraderTransferredEvent(this);
        base.RegisterDomainEvent(traderTransferredEvent);
    }
}