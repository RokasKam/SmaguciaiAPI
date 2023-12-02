using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IProductService
{
    bool AddNewProduct(ProductRequest request);
    bool EditProduct(Guid id,ProductRequest request);
    
    Product GetById(Guid id);

    bool DeleteProduct(Guid id);
    
    List<Product> GetAll(ProductParameters productParameters);
    
}