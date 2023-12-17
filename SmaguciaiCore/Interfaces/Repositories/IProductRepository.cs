using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IProductRepository
{
    
    Product GetById(Guid id);
    Guid AddNewProduct(Product product, Category category, Manufacturer manufacturer);

    bool EditProduct(Product product);

    bool DeleteProduct(Product product, Category category, Manufacturer manufacturer);
    
    IEnumerable<Product> GetAll(ProductParameters productParameters);
}