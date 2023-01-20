// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification;
using CardManagement.Domain.Entities;

namespace CardManagement.Domain.Specification; 

public class TraderByIdWithCardSpec: Specification<Trader>, ISingleResultSpecification {
    public TraderByIdWithCardSpec(string thriveId) {
        Query
            .Where(trader => trader.ThriveId == thriveId);
    }
    
}