// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using ThriveShared;
using ThriveShared.Interfaces;

namespace CardManagement.Infrastructure.Entities;

public class Trader : EntityBase<Guid>, IAggregateRoot {
    public string ThriveId       { get; private set; }
    public bool   TandC          { get; private set; }
    public string Profile        { get; private set; }
    public string CardNumber     { get; private set; }
    public string CardIdentifier { get; private set; }
}