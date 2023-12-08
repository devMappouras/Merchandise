namespace Domain.Entities;

public partial class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; }

    public string ColorCode { get; set; }

    public virtual ICollection<ProductColor> ProductColors { get; set; } = new List<ProductColor>();
}