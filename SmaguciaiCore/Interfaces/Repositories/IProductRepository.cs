using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IProductRepository
{
    
    Product GetById(Guid id);
    Guid AddNewProduct(Product product);

    bool EditProduct(Product product);

    bool DeleteProduct(Guid id);
    
    IEnumerable<Product> GetAll(ProductParameters productParameters);
}