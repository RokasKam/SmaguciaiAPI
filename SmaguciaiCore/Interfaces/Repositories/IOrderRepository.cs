using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IOrderRepository
{
    Guid GetByUserId(Guid id);
    bool AddNewOrder (Order order);
    Order GetById(Guid id);
}