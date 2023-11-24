using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;

namespace SmaguciaiAPI.Controllers;

public class ProductController : BaseController
{
    private readonly IProductService _productService;
    
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    [HttpPost]
    public IActionResult AddNewProduct(ProductRequest request)
    {
        var res = _productService.AddNewProduct(request);
        return Ok(res);
    }
}