using AutoMapper;
using SmaguciaiCore.Responses.Manufacturer;
using SmaguciaiDomain.Entities;

namespace SmaguciaiCore.Mappings;

public class ManufacturerMappingProfile : Profile
{
    public ManufacturerMappingProfile()
    {
        CreateMap<Manufacturer, ManufacturerResponse>();
    }
}