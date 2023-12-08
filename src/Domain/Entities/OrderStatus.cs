namespace Domain.Entities;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string StatusName { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}