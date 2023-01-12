// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification;
using CardTransaction.Domain.Entities;

namespace CardTransaction.Domain.Specification; 

public class TraderByIdWithCardSpec: Specification<Trader>, ISingleResultSpecification {
    public TraderByIdWithCardSpec(Guid traderId, string thriveId) {
        Query
            .Where(trader => trader.Id == traderId && trader.ThriveId == thriveId)
            .Include(trader => trader.Cards);  
    }
    
}