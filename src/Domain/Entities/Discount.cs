namespace Domain.Entities;

public partial class Discount
{
    public int DiscountId { get; set; }

    public string DscountName { get; set; }

    public int DiscountPercentage { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? EndDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}