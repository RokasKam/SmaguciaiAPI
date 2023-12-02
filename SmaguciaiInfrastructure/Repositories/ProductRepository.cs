using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiDomain.Entities;
using SmaguciaiInfrastructure.Data;

namespace SmaguciaiInfrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly SmaguciaiDataContext _dbContext;

    public ProductRepository(SmaguciaiDataContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Product GetById(Guid id)
    {
        var product = _dbContext.Products.FirstOrDefault(x => x.Id == id);

        return product;
    }
    
    public bool AddNewProduct(Product product)
    {
        try
        {
            product.Id = Guid.NewGuid();
            product.RatingAmount = 0;
            product.RatingAverage = 0;
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    public bool EditProduct(Product product)
    {
        try
        {
            var local = _dbContext.Products.Local.FirstOrDefault(oldEntity => oldEntity.Id == product.Id);
            if (local != null)
            {
                _dbContext.Entry(local).State = EntityState.Detached;
            }

            _dbContext.Entry(product).State = EntityState.Modified;
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool DeleteProduct(Guid id)
    {
        try
        {
            var place = _dbContext.Products.SingleOrDefault(entity => entity.Id == id);

            if (place is null)
            {
                throw new Exception("Place not found");
            }

            _dbContext.Products.Remove(place);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
}