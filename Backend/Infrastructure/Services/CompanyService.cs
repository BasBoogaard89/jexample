using Application.Dtos.Filters;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Services;

public class CompanyService(ICompanyRepository repository) : BaseService<Company>(repository), ICompanyService
{
    public override async Task<Company> Save(Company updatedEntity)
    {
        var entity = await repository.GetById(updatedEntity.Id) ?? new Company();

        entity.Name = updatedEntity.Name;
        entity.Address = updatedEntity.Address;
        entity.Vacancies = updatedEntity.Vacancies;

        return await repository.Save(entity);
    }

    public async Task<List<Company>> GetAllFiltered(CompanyFilterDto filters)
    {
        return await repository.GetAllFiltered(filters);
    }
}
