using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Manufacturer;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Services;

public interface IManufacturerService
{
    List<ManufacturerResponse> GetAll();
    ManufacturerResponse GetById(Guid id);
}