// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardTransaction.Infrastructure.Data.Config; 

public class CardConfiguration : IEntityTypeConfiguration<Card> {
    public void Configure(EntityTypeBuilder<Card> builder) {
        builder.ToTable("Cards").HasKey(x => x.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.OwnsOne(t => t.CardStatus, p =>
            {
                p.Property(pp => pp.CardReason).HasColumnName("Card_Reason").HasMaxLength(50);
            });
        
    }
}