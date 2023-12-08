using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> entity)
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_Product Category");

            entity.ToTable("ProductCategory", "product");

            entity.Property(e => e.CategoryName)
            .IsRequired()
            .HasMaxLength(50);

            entity.HasOne(d => d.Group).WithMany(p => p.ProductCategories)
            .HasForeignKey(d => d.GroupId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ProductCategory_CategoryGroup");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ProductCategory> entity);
    }
}
