// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification;

namespace ThriveShared.Interfaces; 

public interface IReadRepository<T> : IReadRepositoryBase<T> where T : class, IAggregateRoot
{
}