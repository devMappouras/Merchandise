namespace Domain.Entities;

public partial class CategoryGroup
{
    public int GroupId { get; set; }

    public string GroupName { get; set; } = string.Empty;

    public virtual ICollection<ProductCategory> ProductCategories { get; set; } = new List<ProductCategory>();

    public void Update(int requestGroupId, string requestGroupName)
    {
        GroupId = requestGroupId;
        GroupName = requestGroupName;
    }
}