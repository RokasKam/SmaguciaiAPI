using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Interfaces.Repositories;

public interface IManufacturerRepository
{
    List<Manufacturer> GetAll();
    Manufacturer GetById(Guid id);
}