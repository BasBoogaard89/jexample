using AutoMapper;
using Domain.Entities;
using Application.Dtos;

namespace Api.Mappings;

public class EntityToDtoMapping : Profile
{
    public EntityToDtoMapping()
    {
        CreateMap<Address, AddressDto>().ReverseMap();
        CreateMap<Company, CompanyDto>().ReverseMap();
        CreateMap<Vacancy, VacancyDto>().ReverseMap();
    }
}
