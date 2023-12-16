using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Order;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    
    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public Guid GetByUserId(Guid id)
    {
        var orderId = _orderRepository.GetByUserId(id);
        return orderId;
    }

    public bool AddNewOrder(OrderRequest orderRequest)
    {
        var order = _mapper.Map<Order>(orderRequest);
        var res = _orderRepository.AddNewOrder(order);
        return res;
    }
}