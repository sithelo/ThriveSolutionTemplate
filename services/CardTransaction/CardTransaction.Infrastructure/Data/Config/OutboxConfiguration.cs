// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardTransaction.Infrastructure.Data.Config; 

public class OutboxConfiguration : IEntityTypeConfiguration<OutboxMessage> {
    public void Configure(EntityTypeBuilder<OutboxMessage> builder) {
        builder.ToTable("OutboxMessage").HasKey(x => x.Id);
        builder.Property(p => p.Id).ValueGeneratedNever();
        builder.Property(p => p.Type).HasMaxLength(200).IsRequired();
        builder.Property(p => p.Content).IsRequired().HasColumnType("nvarchar(max)");
        builder.Property(p => p.OccurredOn).HasColumnName("OccurredOn");
        builder.Property(p => p.ProcessedOn).HasColumnName("ProcessedOn");
        builder.Property(p => p.Error).HasColumnType("nvarchar(max)");
    }
}