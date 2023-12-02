using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ShippingAddressRepository : IShippingAddressRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public ShippingAddressRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    public bool AddNewShippingAddress(ShippingAddress shippingAddress)
    {
        try
        {
            shippingAddress.Id = Guid.NewGuid();
            _dbContext.ShippingAddresses.Add(shippingAddress);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public ShippingAddress GetById(Guid id)
    {
        var shippingAddress = _dbContext.ShippingAddresses.FirstOrDefault(u => u.Id == id);
        return shippingAddress;    
    }
}