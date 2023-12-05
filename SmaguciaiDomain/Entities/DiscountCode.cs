namespace SmaguciaiDomain.Entities;

public class DiscountCode : BaseEntity
{
    public string Code { get; set; }
    public string ExperationDate { get; set; }
    public int Discount { get; set; }
    public string CreationDate { get; set; }
    public Order Order { get; set; }
}