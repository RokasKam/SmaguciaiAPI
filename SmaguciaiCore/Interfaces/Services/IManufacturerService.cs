using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IManufacturerService
{
    List<Manufacturer> GetAll();
}