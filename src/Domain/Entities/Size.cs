namespace Domain.Entities;

public partial class Size
{
    public int SizeId { get; set; }

    public string SizeName { get; set; }

    public string SizeDescription { get; set; }

    public virtual ICollection<ProductSize> ProductSizes { get; set; } = new List<ProductSize>();
}