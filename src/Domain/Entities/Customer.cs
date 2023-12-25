namespace Domain.Entities;

public partial class Customer
{
    public int CustomerId { get; set; }

    public required string Email { get; set; }

    public string Password { get; set; } = string.Empty;

    public string Phone { get; set; } = string.Empty;

    public required string Name { get; set; }

    public required string LastName { get; set; }

    public virtual ICollection<CustomerAddress> CustomerAddresses { get; set; } = new List<CustomerAddress>();

    public virtual ICollection<CustomerPayment> CustomerPayments { get; set; } = new List<CustomerPayment>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<ShoppingSession> ShoppingSessions { get; set; } = new List<ShoppingSession>();

    public void Update(string requestEmail, string requestPhone, string requestName, string requestLastName)
    {
        Email = requestEmail;
        Phone = requestPhone;
        Name = requestName;
        LastName = requestLastName; 
    }
}