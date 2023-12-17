using SmaguciaiCore.Requests.Order;
using SmaguciaiCore.Responses.Order;

namespace SmaguciaiCore.Interfaces.Services;

public interface IOrderService
{
    Guid GetByUserId(Guid id);
    bool AddNewOrder(OrderRequest orderRequest);
    OrderResponse GetById(Guid id);

}