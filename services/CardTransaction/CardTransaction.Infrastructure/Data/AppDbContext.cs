// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.

using System.Reflection;
using CardTransaction.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ThriveShared;
using ThriveShared.Interfaces;

namespace CardTransaction.Infrastructure.Data;

public class AppDbContext : DbContext {

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<Trader> Traders { get; set; }
    public DbSet<Card>   Cards   { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken()) {
        var result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return result;
    }

    public override int SaveChanges() {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}