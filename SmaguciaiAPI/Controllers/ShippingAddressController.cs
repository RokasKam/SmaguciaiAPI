using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.ShippingAddress;

namespace SmaguciaiAPI.Controllers;

public class ShippingAddressController : BaseController
{
    private readonly IAuthService _authService;
    private readonly IShippingAddressService _shippingAddressService;
    private readonly IJwtService _jwtService;
    
    public ShippingAddressController(IAuthService authService, IShippingAddressService shippingAddressService, IJwtService jwtService)
    {
        _authService = authService;
        _shippingAddressService = shippingAddressService;
        _jwtService = jwtService;
    }
    [HttpPost]
    public IActionResult AddNewShippingAddress(ShippingAddressRequest request)
    {
        var res = _shippingAddressService.AddNewShippingAddress(request);
        return Ok(res);
    }
    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public IActionResult GetMe()
    {
        var shippingAddress = _shippingAddressService.GetById(Guid.Parse(User.FindFirstValue(ClaimTypes.Sid)));
        return Ok(shippingAddress);
    }
    
    [HttpPut("{id:guid}")]
    public IActionResult EditShippingAddress(Guid id, ShippingAddressRequest request)
    {
        var res = _shippingAddressService.EditShippingAddress(id,request);
        return Ok(res);
    }
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteShippingAddress(Guid id)
    {
        _shippingAddressService.DeleteShippingAddress(id);
        return Ok();
    }
}