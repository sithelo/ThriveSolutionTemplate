// Copyright (C) Thrive. All rights reserved
// Licensed under the Apache License, Version 2.0.


using System.Reflection;
using CardManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CardManagement.Infrastructure.Data;

public class AppDbContext : DbContext {

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {
    }

    public DbSet<Trader> Traders { get; set; }

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