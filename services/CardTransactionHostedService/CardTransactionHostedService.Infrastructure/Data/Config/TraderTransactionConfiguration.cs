using CardTransactionHostedService.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CardTransactionHostedService.Infrastructure.Data.Config;

public class TraderTransactionConfiguration : IEntityTypeConfiguration<TraderTransaction>
{
  public void Configure(EntityTypeBuilder<TraderTransaction> builder)
  {
    builder.Property(t => t.RequestDateUtc)
        .IsRequired();
    builder.Property(t => t.Id)
        .IsRequired();
    builder.Property(t => t.Amount)
        .IsRequired();
    builder.Property(t => t.TransactionId)
        .IsRequired();
    builder.Property(t => t.Reason)
        .HasMaxLength(Constants.DEFAULT_URI_LENGTH)
        .IsRequired();
  }
}
