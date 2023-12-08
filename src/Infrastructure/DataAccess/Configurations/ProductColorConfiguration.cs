using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class ProductColorConfiguration : IEntityTypeConfiguration<ProductColor>
    {
        public void Configure(EntityTypeBuilder<ProductColor> entity)
        {
            entity.ToTable("ProductColor", "product");

            entity.HasOne(d => d.Color).WithMany(p => p.ProductColors)
            .HasForeignKey(d => d.ColorId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductColor_Color");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductColors)
            .HasForeignKey(d => d.ProductId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductColor_Product");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ProductColor> entity);
    }
}
