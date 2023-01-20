// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardManagement.Infrastructure.Data.Config; 

public class TraderConfiguration : IEntityTypeConfiguration<Trader> {
    public void Configure(EntityTypeBuilder<Trader> builder) {
        builder.ToTable("Traders");
       
        builder.Property(t => t.CardIdentifier).HasMaxLength(32).IsRequired();
        builder.Property(t => t.Profile).HasMaxLength(16).IsRequired();
        
    }
}