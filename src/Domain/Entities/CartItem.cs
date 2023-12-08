namespace Domain.Entities;

public partial class CartItem
{
    public int CartItemId { get; set; }

    public int SessionId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Product Product { get; set; }

    public virtual ShoppingSession Session { get; set; }
}