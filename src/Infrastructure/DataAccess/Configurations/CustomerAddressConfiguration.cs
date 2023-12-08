using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class CustomerAddressConfiguration : IEntityTypeConfiguration<CustomerAddress>
    {
        public void Configure(EntityTypeBuilder<CustomerAddress> entity)
        {
            entity.ToTable("CustomerAddress", "customer");

            entity.Property(e => e.City)
            .IsRequired()
            .HasMaxLength(50);
            entity.Property(e => e.PostalCode)
            .IsRequired()
            .HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.StreetAddress)
            .IsRequired()
            .HasMaxLength(200);

            entity.HasOne(d => d.Country).WithMany(p => p.CustomerAddresses)
            .HasForeignKey(d => d.CountryId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerAddress_Country");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerAddresses)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerAddress_Customer");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CustomerAddress> entity);
    }
}
