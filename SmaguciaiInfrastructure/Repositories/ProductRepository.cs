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
}