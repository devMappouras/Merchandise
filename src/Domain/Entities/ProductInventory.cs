namespace Domain.Entities;

public partial class ProductInventory
{
    public int InventoryId { get; set; }

    public int QuantityAvailable { get; set; }

    public int QuantityReserved { get; set; }

    public DateTime LastUpdated { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}