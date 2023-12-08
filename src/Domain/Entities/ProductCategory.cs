namespace Domain.Entities;

public partial class ProductCategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; }

    public int GroupId { get; set; }

    public virtual CategoryGroup Group { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}