using Microsoft.EntityFrameworkCore;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Requests.Product;
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
    
    public Guid AddNewProduct(Product product)
    {
        product.Id = Guid.NewGuid();
        product.RatingAmount = 0;
        product.RatingAverage = 0;
        _dbContext.Products.Add(product);
        _dbContext.SaveChanges();
        return product.Id;
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
            var product = _dbContext.Products.SingleOrDefault(entity => entity.Id == id);

            if (product is null)
            {
                throw new Exception("Product not found");
            }

            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
        
    public IEnumerable<Product> GetAll(ProductParameters productParameters)
    {
        
        IQueryable<Product> entities = _dbContext.Products;

        if (productParameters.Manufacturerid != null)
        {
            entities = entities
                .Where(i => i.ManufacturerId == productParameters.Manufacturerid);
        }
        if (productParameters.Categoryid != null)
        {
            entities = entities
                .Where(i => i.CategoryId == productParameters.Categoryid);
        }
        if (productParameters.gender != null)
        {
            entities = entities
                .Where(i => i.Gender == productParameters.gender);
        }
        if (productParameters.priceFrom != null && productParameters.priceTo != null)
        {
            entities = entities
                .Where(i => i.Price >= productParameters.priceFrom && i.Price <= productParameters.priceTo);
        }

        if (productParameters.orderby == Orderby.PriceAcending)
        {
            entities = entities
                .OrderBy(x => x.Price);
        }
        
        if (productParameters.orderby == Orderby.PriceDescending)
        {
            entities = entities
                .OrderByDescending(x => x.Price);
        }
        if (productParameters.orderby == Orderby.RatingAcending)
        {
            entities = entities
                .OrderBy(x => x.RatingAverage);
        }
        if (productParameters.orderby == Orderby.RatingDescending)
        {
            entities = entities
                .OrderByDescending(x => x.RatingAverage);
        }
        entities = entities
            .Skip((productParameters.PageNumber - 1) * productParameters.PageSize)
            .Take(productParameters.PageSize);

        return entities.ToList();
    }
}