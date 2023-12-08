namespace Domain.Entities;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryName { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();
}