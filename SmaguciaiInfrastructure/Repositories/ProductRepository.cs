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
    
    public Guid AddNewProduct(Product product, Category category, Manufacturer manufacturer)
    {
        product.Id = Guid.NewGuid();
        product.RatingAmount = 0;
        product.RatingAverage = 0;
        _dbContext.Products.Add(product);

        category.AmountOfProducts++;
        _dbContext.Entry(category).State = EntityState.Modified;
        manufacturer.AmountOfProducts++;
        _dbContext.Entry(manufacturer).State = EntityState.Modified;
        
        _dbContext.SaveChanges();
        return product.Id;
    }
    public bool EditProduct(Product updatedProduct)
    {
        try
        {
            var existingProduct = _dbContext.Products.Include(p => p.Category)
                .Include(p => p.Manufacturer)
                .FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            // Check if category has changed
            if (existingProduct.CategoryId != updatedProduct.CategoryId)
            {
                var oldCategory = _dbContext.Categories.Find(existingProduct.CategoryId);
                if (oldCategory != null && oldCategory.AmountOfProducts > 0)
                {
                    oldCategory.AmountOfProducts--;
                }

                var newCategory = _dbContext.Categories.Find(updatedProduct.CategoryId);
                if (newCategory != null)
                {
                    newCategory.AmountOfProducts++;
                }
            }

            // Check if manufacturer has changed
            if (existingProduct.ManufacturerId != updatedProduct.ManufacturerId)
            {
                var oldManufacturer = _dbContext.Manufacturers.Find(existingProduct.ManufacturerId);
                if (oldManufacturer != null && oldManufacturer.AmountOfProducts > 0)
                {
                    oldManufacturer.AmountOfProducts--;
                }

                var newManufacturer = _dbContext.Manufacturers.Find(updatedProduct.ManufacturerId);
                if (newManufacturer != null)
                {
                    newManufacturer.AmountOfProducts++;
                }
            }

            _dbContext.Entry(existingProduct).CurrentValues.SetValues(updatedProduct);
            _dbContext.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }


    public bool DeleteProduct(Product product, Category category, Manufacturer manufacturer)
    {
        try
        {
            if (product == null)
            {
                throw new Exception("Product not found");
            }

            _dbContext.Products.Remove(product);

            category.AmountOfProducts = Math.Max(0, category.AmountOfProducts - 1);
            _dbContext.Entry(category).State = EntityState.Modified;
            manufacturer.AmountOfProducts = Math.Max(0, manufacturer.AmountOfProducts - 1);
            _dbContext.Entry(manufacturer).State = EntityState.Modified;

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