// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using Ardalis.Specification.EntityFrameworkCore;
using ThriveShared.Interfaces;

namespace CardTransaction.Infrastructure.Data; 

public class CardTransactionRepository<T> : RepositoryBase<T>, IRepository<T> where T : class, IAggregateRoot
{
    public CardTransactionRepository(AppDbContext dbContext) : base(dbContext)
    {
    }
}