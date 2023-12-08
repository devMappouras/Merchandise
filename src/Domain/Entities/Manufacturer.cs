namespace Domain.Entities;

public partial class Manufacturer
{
    public int ManufacturerId { get; set; }

    public string ManufacturerName { get; set; }

    public string Location { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}