namespace Domain.Entities;

public partial class ShoppingSession
{
    public int SessionId { get; set; }

    public int CustomerId { get; set; }

    public decimal TotalPrice { get; set; }

    public DateTime StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual Customer Customer { get; set; }
}