// Copyright (C) Sithelo Ngwenya. All rights reserved
// Licensed under the Apache License, Version 2.0.

using CardTransaction.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardTransaction.Infrastructure.Data.Config; 

public class TraderConfiguration : IEntityTypeConfiguration<Trader> {
    public void Configure(EntityTypeBuilder<Trader> builder) => throw new NotImplementedException();
}