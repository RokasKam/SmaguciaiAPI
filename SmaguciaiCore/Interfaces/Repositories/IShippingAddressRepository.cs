using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IShippingAddressRepository
{
    bool AddNewShippingAddress(ShippingAddress shippingAddress);
    ShippingAddress GetById(Guid id);
}