// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardTransaction.Infrastructure.Data.Config; 

public class TraderConfiguration : IEntityTypeConfiguration<Trader> {
    public void Configure(EntityTypeBuilder<Trader> builder) {
        builder.ToTable("Traders").HasKey(x => x.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(t => t.ThriveId).HasMaxLength(6).IsRequired();
        builder.Property(t => t.KYC).HasDefaultValue(false);
        builder.OwnsOne(t => t.Fee, p =>
            {
                p.Property(pp => pp.Currency).HasColumnName("Fee_Currency").HasMaxLength(50);
                p.Property(pp => pp.Amount).HasColumnName("Fee_Amount");
            });
        builder.OwnsOne(t => t.CardBalance, p =>
        {
            p.Property(pp => pp.Currency).HasColumnName("CardBalance_Currency").HasMaxLength(50);
            p.Property(pp => pp.Amount).HasColumnName("CardBalance_Amount");
        });
        builder.OwnsOne(t => t.WalletBalance, p =>
        {
            p.Property(pp => pp.Currency).HasColumnName("WalletBalance_Currency").HasMaxLength(50);
            p.Property(pp => pp.Amount).HasColumnName("WalletBalance_Amount");
        });
        builder.OwnsOne(t => t.AdvanceBalance, p =>
        {
            p.Property(pp => pp.Currency).HasColumnName("AdvanceBalance_Currency").HasMaxLength(50);
            p.Property(pp => pp.Amount).HasColumnName("AdvanceBalance_Amount");
        });
        
        builder.Property(t => t.Currency).HasMaxLength(4).IsRequired();
        builder.Property(t => t.Currency).HasMaxLength(4).IsRequired();
        
    }
}