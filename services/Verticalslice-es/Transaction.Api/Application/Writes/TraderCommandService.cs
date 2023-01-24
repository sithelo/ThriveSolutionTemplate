// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Clarity;
using Transaction.Domain;
using Transaction.Domain.DomainServices;
using static Transaction.Api.Application.Writes.TraderCommands;

namespace Transaction.Api.Application.Writes; 

public class TraderCommandService : ApplicationService<Trader, TraderState, TraderId> {
    public TraderCommandService(IAggregateStore store, Services.IsNewTrader isNewTrader) : base(store) {
        OnNewAsync<CreateTrader>(
            cmd => new TraderId(cmd.ThriveId),
            (trader, cmd, _) => trader.CreateTrader(
                new TraderId(Guid.NewGuid().ToString()),
                new ThriveId(cmd.ThriveId),
                cmd.ProfileNumber,
                DateTimeOffset.Now,
                isNewTrader)
        );
    }
}