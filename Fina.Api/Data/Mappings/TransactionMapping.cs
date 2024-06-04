using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mapping;

public class TransactionMapping : IEntityTypeConfiguration<Transaction>
{
    public void Configure(EntityTypeBuilder<Transaction> builder)
    {
        builder.ToTable("Transaction");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.TransactionType)
            .IsRequired(true)
            .HasColumnType("SMALLINT");

        builder.Property(x => x.Amount)
        .IsRequired(true)
        .HasColumnType("NUMERIC");

        builder.Property(x => x.CreatedAt)
            .IsRequired(true);
        builder.Property(x => x.PaidOrReceiveAt)
            .IsRequired(false);

        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);

        //Relacionamento Tabelas
        builder.HasOne(t => t.Category)
            .WithMany(c => c.Transactions)
            .HasForeignKey(t => t.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
