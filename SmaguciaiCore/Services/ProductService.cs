using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }
    
    public ProductResponse GetById(Guid id)
    {
        var product = _productRepository.GetById(id);
        var productResponse = _mapper.Map<ProductResponse>(product);
        return productResponse;
    }
    
    public Guid AddNewProduct(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        var res = _productRepository.AddNewProduct(product);
        return res;
    }
    public bool EditProduct(Guid id,ProductRequest request)
    {
        try
        {
            var productToUpdate = _productRepository.GetById(id);
            if (productToUpdate is null)
            {
                throw new Exception("Place with provided id does not exist");
            }

            var product = _mapper.Map<Product>(request);
            product.Id = id;
            var res = _productRepository.EditProduct(product);
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
            _productRepository.DeleteProduct(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
    public List<ProductResponse> GetAll(ProductParameters productParameters)
    {
        var products = _productRepository.GetAll(productParameters);
        var productsResponseList = products.Select(x => _mapper.Map<ProductResponse>(x)).ToList();
        return productsResponseList;
    }
}