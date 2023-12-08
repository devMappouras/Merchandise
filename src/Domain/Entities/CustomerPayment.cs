namespace Domain.Entities;

public partial class CustomerPayment
{
    public int PaymentId { get; set; }

    public int CustomerId { get; set; }

    public string CardNumber { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<PaymentDetail> PaymentDetails { get; set; } = new List<PaymentDetail>();
}