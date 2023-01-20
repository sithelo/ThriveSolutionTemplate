// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification;
using CardTransaction.Domain.Entities;

namespace CardTransaction.Domain.Specification;

public class TraderByIdSpec : Specification<Trader>, ISingleResultSpecification {
    public TraderByIdSpec(string thriveId) {
        Query
            .Where(trader => trader.ThriveId == thriveId);
    }
}