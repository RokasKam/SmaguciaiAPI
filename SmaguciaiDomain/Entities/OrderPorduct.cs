namespace SmaguciaiDomain.Entities;

public class OrderPorduct : BaseEntity
{
    public int Amount { get; set; }
    public Guid ProductId { get; set; }
    public Product Product { get; set; }
    public Guid OrderId { get; set; }
    public Order Order { get; set; }
}