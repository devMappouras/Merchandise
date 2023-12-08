namespace Domain.Entities;

public partial class Order
{
    public int OrderId { get; set; }

    public int CustomerId { get; set; }

    public DateTime OrderDate { get; set; }

    public decimal TotalPrice { get; set; }

    public int OrderStatusId { get; set; }

    public int ShippingAddressId { get; set; }

    public int PaymentDetailId { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual OrderStatus OrderStatus { get; set; }

    public virtual PaymentDetail PaymentDetail { get; set; }

    public virtual CustomerAddress ShippingAddress { get; set; }
}