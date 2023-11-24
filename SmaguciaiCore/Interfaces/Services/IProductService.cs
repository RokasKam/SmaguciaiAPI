using SmaguciaiCore.Requests.Product;

namespace SmaguciaiCore.Interfaces.Services;

public interface IProductService
{
    bool AddNewProduct(ProductRequest request);
}