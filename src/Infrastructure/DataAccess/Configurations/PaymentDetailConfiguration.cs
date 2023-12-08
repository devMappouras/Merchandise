using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Models.Configurations
{
    public partial class PaymentDetailConfiguration : IEntityTypeConfiguration<PaymentDetail>
    {
        public void Configure(EntityTypeBuilder<PaymentDetail> entity)
        {
            entity.ToTable("PaymentDetail", "order");

            entity.Property(e => e.AdditionalDetails).HasMaxLength(500);
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");

            entity.HasOne(d => d.Payment).WithMany(p => p.PaymentDetails)
            .HasForeignKey(d => d.PaymentId)
            .HasConstraintName("FK_PaymentDetail_CustomerPayment");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PaymentDetail> entity);
    }
}
