using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IProductRepository
{
    bool AddNewProduct(Product product);
}