using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Services;

public class ManufacturerService : IManufacturerService
{
    private readonly IManufacturerRepository _manufacturerRepository;
    private readonly IMapper _mapper;
    
    public ManufacturerService(IManufacturerRepository manufacturerRepository, IMapper mapper)
    {
        _manufacturerRepository = manufacturerRepository;
        _mapper = mapper;
    }
    public List<Manufacturer> GetAll()
    {
        var products = _manufacturerRepository.GetAll();
        var placesResponseList = products.Select(x => _mapper.Map<Manufacturer>(x)).ToList();
        return placesResponseList;
    }
}