using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ManufacturerRepository : IManufacturerRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public ManufacturerRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Manufacturer GetById(Guid id)
    {
        var manufacturer = _dbContext.Manufacturers.FirstOrDefault(u => u.Id == id);
        return manufacturer;  
    }
    public List<Manufacturer> GetAll()
    {
        
        IQueryable<Manufacturer> entities = _dbContext.Manufacturers;

        return entities.ToList();
    }
}