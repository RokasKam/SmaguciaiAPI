using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
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
    public bool AddNewProduct(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        var res = _productRepository.AddNewProduct(product);
        return res;
    }
}