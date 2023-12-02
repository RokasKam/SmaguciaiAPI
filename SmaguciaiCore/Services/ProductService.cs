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
    
    public Product GetById(Guid id)
    {
        var place = _productRepository.GetById(id);
        var placeResponse = _mapper.Map<Product>(place);

        return placeResponse;
    }
    
    public bool AddNewProduct(ProductRequest request)
    {
        var product = _mapper.Map<Product>(request);
        var res = _productRepository.AddNewProduct(product);
        return res;
    }
    public bool EditProduct(Guid id,ProductRequest request)
    {
        try
        {
            var placeToUpdate = _productRepository.GetById(id);
            if (placeToUpdate is null)
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
    public List<Product> GetAll(ProductParameters productParameters)
    {
        var products = _productRepository.GetAll(productParameters);
        var placesResponseList = products.Select(x => _mapper.Map<Product>(x)).ToList();
        return placesResponseList;
    }
}