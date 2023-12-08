using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class ShoppingSessionConfiguration : IEntityTypeConfiguration<ShoppingSession>
    {
        public void Configure(EntityTypeBuilder<ShoppingSession> entity)
        {
            entity.HasKey(e => e.SessionId);

            entity.ToTable("ShoppingSession", "cart");

            entity.Property(e => e.EndDateTime).HasColumnType("datetime");
            entity.Property(e => e.StartDateTime).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.ShoppingSessions)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_ShoppingSession_Customer");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<ShoppingSession> entity);
    }
}
