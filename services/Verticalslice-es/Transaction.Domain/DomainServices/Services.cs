// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace Transaction.Domain.DomainServices; 

public static class Services {
    public delegate ValueTask<bool> IsNewTrader(ThriveId thriveId, string profileNumber);
}