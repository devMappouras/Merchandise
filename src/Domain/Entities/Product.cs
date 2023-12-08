namespace Domain.Entities;

public partial class Product
{
    public Product(string productName,
                   string description,
                   decimal price,
                   int discountId,
                   int categoryId,
                   int? manufacturerId,
                   int? inventoryId)
    {
        ProductName = productName;
        Description = description;
        Price = price;
        DiscountId = discountId;
        CategoryId = categoryId;
        ManufacturerId = manufacturerId;
        InventoryId = inventoryId;
        Category = new ProductCategory();
        Discount = new Discount();
        Inventory = new ProductInventory();
        Manufacturer = new Manufacturer();
        CartItems = new HashSet<CartItem>();
        OrderItems = new HashSet<OrderItem>();
        ProductColors = new HashSet<ProductColor>();
        ProductSizes = new HashSet<ProductSize>();
    }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int DiscountId { get; set; }

    public int CategoryId { get; set; }

    public int? ManufacturerId { get; set; }

    public int? InventoryId { get; set; }

    public virtual ProductCategory Category { get; set; }

    public virtual Discount Discount { get; set; }

    public virtual ProductInventory Inventory { get; set; }

    public virtual Manufacturer Manufacturer { get; set; }

    public virtual ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();

    public void Update(string productName,
                       string description,
                       decimal price,
                       int discountId,
                       int categoryId,
                       int? manufacturerId,
                       int? inventoryId)
    {
        ProductName = productName;
        Description = description;
        Price = price;
        DiscountId = discountId;
        CategoryId = categoryId;
        ManufacturerId = manufacturerId;
        InventoryId = inventoryId;
    }
}