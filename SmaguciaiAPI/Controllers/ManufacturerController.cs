using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;

namespace SmaguciaiAPI.Controllers;

public class ManufacturerController : BaseController
{
    private readonly IManufacturerService _manufacturerService;
    
    public ManufacturerController(IManufacturerService manufacturerService)
    {
        _manufacturerService = manufacturerService;
    }
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_manufacturerService.GetAll());
    }
}