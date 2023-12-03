namespace SmaguciaiCore.Responses.Manufacturer;

public class ManufacturerResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int AmountOfProducts { get; set; }
    public string Country { get; set; }
    public string PhoneNumber { get; set; }
    public string Address { get; set; }
}