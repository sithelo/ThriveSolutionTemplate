﻿// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

namespace ThriveShared.Interfaces; 

public interface IDomainEventDispatcher {
    Task DispatchAndClearEvents(IEnumerable<EntityBase<Guid>> entitiesWithEvents);  
}