using Fina.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Fina.Api.Data.Mapping;

public class CategoryMapping : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Category");
        
        builder.HasKey(x => x.Id);

        // titulo
        builder.Property(x => x.Title)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(80);

        builder.Property(x => x.Description)
            .IsRequired(false)
            .HasColumnType("VARCHAR")
            .HasMaxLength(255);
            
        builder.Property(x => x.UserId)
            .IsRequired(true)
            .HasColumnType("VARCHAR")
            .HasMaxLength(160);
    }
}
