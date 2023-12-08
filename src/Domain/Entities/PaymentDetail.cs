namespace Domain.Entities;

public partial class PaymentDetail
{
    public int PaymentDetailId { get; set; }

    public int? PaymentId { get; set; }

    public DateTime TransactionDate { get; set; }

    public int PaymentStatusId { get; set; }

    public string AdditionalDetails { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual CustomerPayment Payment { get; set; }
}