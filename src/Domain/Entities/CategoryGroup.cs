namespace Domain.Entities;

public partial class CategoryGroup
{
    public int GroupId { get; set; }

    public string GroupName { get; set; }

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();
}