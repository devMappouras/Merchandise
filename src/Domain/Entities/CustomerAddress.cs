namespace Domain.Entities;

public partial class CustomerAddress
{
    public int CustomerAddressId { get; set; }

    public int CustomerId { get; set; }

    public string StreetAddress { get; set; }

    public string City { get; set; }

    public string State { get; set; }

    public string PostalCode { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; }

    public virtual Customer Customer { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}