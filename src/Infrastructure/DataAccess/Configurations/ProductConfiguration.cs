using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.ToTable("Product", "product");

            entity.Property(e => e.Description).HasMaxLength(350);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName)
            .IsRequired()
            .HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
            .HasForeignKey(d => d.CategoryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_ProductCategory");

            entity.HasOne(d => d.Discount).WithMany(p => p.Products)
            .HasForeignKey(d => d.DiscountId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_Product_Discount");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Products)
            .HasForeignKey(d => d.InventoryId)
            .HasConstraintName("FK_Product_ProductInventory");

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
            .HasForeignKey(d => d.ManufacturerId)
            .HasConstraintName("FK_Product_Manufacturer");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Product> entity);
    }
}
