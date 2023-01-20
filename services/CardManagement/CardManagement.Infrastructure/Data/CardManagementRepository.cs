// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification.EntityFrameworkCore;
using ThriveShared.Interfaces;

namespace CardManagement.Infrastructure.Data; 

public class CardManagementRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
    public CardManagementRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}