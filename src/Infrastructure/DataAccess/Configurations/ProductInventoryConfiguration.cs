using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class ProductInventoryConfiguration : IEntityTypeConfiguration<ProductInventory>
    {
        public void Configure(EntityTypeBuilder<ProductInventory> entity)
        {
            entity.HasKey(e => e.InventoryId).HasName("PK_Product Inventory");

            entity.ToTable("ProductInventory", "product");

            entity.Property(e => e.LastUpdated).HasColumnType("datetime");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ProductInventory> entity);
    }
}
