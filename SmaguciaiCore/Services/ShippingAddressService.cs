using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Requests.ShippingAddress;
using SmaguciaiCore.Responses.User;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ShippingAddressService : IShippingAddressService
{
    private readonly IShippingAddressRepository _shippingAddressRepository;
    private readonly IMapper _mapper;
    
    public ShippingAddressService(IShippingAddressRepository shippingAddressRepository, IMapper mapper)
    {
        _shippingAddressRepository = shippingAddressRepository;
        _mapper = mapper;
    }
    public bool AddNewShippingAddress(ShippingAddressRequest request)
    {
        var shippingAddress = _mapper.Map<ShippingAddress>(request);
        var res = _shippingAddressRepository.AddNewShippingAddress(shippingAddress);
        return res;
    }
    
    public ShippingAddressResponse GetById(Guid id)
    {
        var shippingAddress = _shippingAddressRepository.GetById(id);
        var response = _mapper.Map<ShippingAddressResponse>(shippingAddress);
        return response;
    }
}