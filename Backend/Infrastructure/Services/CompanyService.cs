using Domain.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;

namespace Infrastructure.Services;

public class CompanyService(ICompanyRepository companyRepository) : BaseService<Company>(companyRepository), ICompanyService
{
    public override async Task<Company> Save(Company updatedEntity)
    {
        var entity = await companyRepository.GetById(updatedEntity.Id) ?? new Company();

        entity.Name = updatedEntity.Name;
        entity.Address = updatedEntity.Address;
        entity.Vacancies = updatedEntity.Vacancies;

        return await companyRepository.Save(entity);
    }
}
