using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class CustomerPaymentConfiguration : IEntityTypeConfiguration<CustomerPayment>
    {
        public void Configure(EntityTypeBuilder<CustomerPayment> entity)
        {
            entity.HasKey(e => e.PaymentId);

            entity.ToTable("CustomerPayment", "customer");

            entity.Property(e => e.CardNumber).HasMaxLength(50);
            entity.Property(e => e.ExpiryDate).HasColumnType("date");

            entity.HasOne(d => d.Customer).WithMany(p => p.CustomerPayments)
            .HasForeignKey(d => d.CustomerId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_CustomerPayment_Customer");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<CustomerPayment> entity);
    }
}
