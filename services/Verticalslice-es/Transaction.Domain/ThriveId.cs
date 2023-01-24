// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Clarity;

namespace Transaction.Domain; 

public record ThriveId(string Value) : AggregateId(Value);