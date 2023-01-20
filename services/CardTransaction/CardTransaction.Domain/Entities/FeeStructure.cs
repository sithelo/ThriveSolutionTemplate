// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using ThriveShared;
using ThriveShared.Interfaces;

namespace CardTransaction.Domain.Entities;

public class FeeStructure : EntityBase<Guid>, IAggregateRoot {
    public string Type   { get; private set; }
    public float  Value  { get; private set; }
    public string Symbol { get; private set; }
}