// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification;

namespace ThriveShared.Interfaces; 

public interface IRepository<T> : IRepositoryBase<T> where T : class, IAggregateRoot
{
}