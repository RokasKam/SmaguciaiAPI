using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IProductRepository
{
    
    Product GetById(Guid id);
    bool AddNewProduct(Product product);

    bool EditProduct(Product product);

    bool DeleteProduct(Guid id);
}