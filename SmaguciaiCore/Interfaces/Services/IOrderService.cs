using SmaguciaiCore.Requests.Order;

namespace SmaguciaiCore.Interfaces.Services;

public interface IOrderService
{
    Guid GetByUserId(Guid id);
    bool AddNewOrder(OrderRequest orderRequest);
}