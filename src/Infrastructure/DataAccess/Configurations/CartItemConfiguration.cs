using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.DataAccess.Configurations;

public partial class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
{
    public void Configure(EntityTypeBuilder<CartItem> entity)
    {
        entity.ToTable("CartItem", "cart");

        entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

        entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
        .HasForeignKey(d => d.ProductId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CartItem_Product");

        entity.HasOne(d => d.Session).WithMany(p => p.CartItems)
        .HasForeignKey(d => d.SessionId)
        .OnDelete(DeleteBehavior.ClientSetNull)
        .HasConstraintName("FK_CartItem_ShoppingSession");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<CartItem> entity);
}
