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
    
    [HttpGet("{id:guid}")]
    public IActionResult GetById(Guid id)
    {
        return Ok(_productService.GetById(id));
    }
    
    [HttpPost]
    public IActionResult AddNewProduct(ProductRequest request)
    {
        var res = _productService.AddNewProduct(request);
        return Ok(res);
    }
    [HttpPut("{id:guid}")]
    public IActionResult EditProduct(Guid id, ProductRequest request)
    {
        var res = _productService.EditProduct(id,request);
        return Ok(res);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteProduct(Guid id)
    {
        _productService.DeleteProduct(id);
        return Ok();
    }
    [HttpGet]
    public IActionResult GetAll([FromQuery] ProductParameters placesParameters)
    {
        return Ok(_productService.GetAll(placesParameters));
    }
}