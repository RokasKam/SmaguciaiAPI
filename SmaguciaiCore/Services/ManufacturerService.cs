using AutoMapper;
using SmaguciaiCore.Interfaces.Repositories;
using SmaguciaiCore.Interfaces.Services;
using SmaguciaiCore.Requests.Product;
using SmaguciaiCore.Responses.Manufacturer;
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
    public List<ManufacturerResponse> GetAll()
    {
        var manufacturers = _manufacturerRepository.GetAll();
        var manufacturersToList = manufacturers.Select(x => _mapper.Map<ManufacturerResponse>(x)).ToList();
        return manufacturersToList;
    }
    
    public ManufacturerResponse GetById(Guid id)
    {
        var manufacturer = _manufacturerRepository.GetById(id);
        var response = _mapper.Map<ManufacturerResponse>(manufacturer);
        return response;
    }
}