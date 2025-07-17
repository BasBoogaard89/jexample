using Application.Dtos;
using AutoMapper;
using Domain.Entities;

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
