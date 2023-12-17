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
    private readonly ICategoryRepository _categoryRepository;
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMapper _mapper;
    
    public ProductService(IProductRepository productRepository, IMapper mapper, ICategoryRepository categoryRepository, IManufacturerRepository manufacturerRepository)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
        _manufacturerRepository = manufacturerRepository;
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
        var category = _categoryRepository.GetById(request.CategoryId);
        var manufacturer = _manufacturerRepository.GetById(request.ManufacturerId);
        var res = _productRepository.AddNewProduct(product, category, manufacturer);
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
            var productToDelete = _productRepository.GetById(id);
            if (productToDelete == null)
            {
                throw new Exception("Product not found");
            }

            var category = _categoryRepository.GetById(productToDelete.CategoryId);
            if (category == null)
            {
                throw new Exception("Category not found");
            }
            var manufacturer = _manufacturerRepository.GetById(productToDelete.ManufacturerId);
            if (manufacturer == null)
            {
                throw new Exception("Category not found");
            }
            
            _productRepository.DeleteProduct(productToDelete, category, manufacturer);
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