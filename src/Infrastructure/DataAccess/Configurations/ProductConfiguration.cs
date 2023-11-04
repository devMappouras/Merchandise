using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Products;

namespace Infrastructure.DataAccess.Configurations;

internal class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Name).IsRequired().HasMaxLength(100); // Adjust the maximum length as needed
        builder.Property(p => p.Price).HasColumnType("decimal(18, 2)"); // Adjust precision and scale as needed
        builder.Property(p => p.Stock); // You can configure Stock property as required
    }
}