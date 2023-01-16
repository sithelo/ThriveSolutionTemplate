// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardTransaction.Infrastructure.Data.Config; 

public class TraderConfiguration : IEntityTypeConfiguration<Trader> {
    public void Configure(EntityTypeBuilder<Trader> builder) {
        builder.ToTable("Traders");
        builder.OwnsOne(t => t.Fee, p =>
            {
                p.Property(pp => pp.Currency).HasColumnName("Fee_Currency").HasMaxLength(50);
                p.Property(pp => pp.Amount).HasColumnName("Fee_Amount");
            });
        builder.Property(t => t.Currency).HasMaxLength(4).IsRequired();
        builder.Property(t => t.Currency).HasMaxLength(4).IsRequired();
        
    }
}