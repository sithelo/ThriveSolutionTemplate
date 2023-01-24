// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace Transaction.Domain.Cards; 

public record CardTransaction {
    
    public Fee Fee { get; private set; }
}

public record Fee { }