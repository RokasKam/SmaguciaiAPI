using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public OrderRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public Guid GetByUserId(Guid id)
    {
        var order = _dbContext.Orders.FirstOrDefault(o => o.UserId == id);
        return order.Id;  
    }
    
    public Order GetById(Guid id)
    {
        var order = _dbContext.Orders.FirstOrDefault(x => x.Id == id);

        return order;
    }
    
    public bool AddNewOrder(Order order)
    {
        order.Id = Guid.NewGuid();
        order.IsPaid = false;
        order.CreationDate = DateTime.Now;
        _dbContext.Orders.Add(order);
        _dbContext.SaveChanges();
        return true;
    }
}