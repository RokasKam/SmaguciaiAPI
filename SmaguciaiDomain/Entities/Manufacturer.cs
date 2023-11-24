namespace SmaguciaiDomain.Entities;

public class Manufacturer : BaseEntity
{
    public string Name { get; set; }
    public int AmountOfProducts { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
    public ICollection<Product> Product { get; set; }
}