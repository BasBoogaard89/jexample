using Application.Dtos.Filters;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Services;

public class VacancyService(IVacancyRepository repository) : BaseService<Vacancy>(repository), IVacancyService
{
    public override async Task<Vacancy> Save(Vacancy updatedEntity)
    {
        var entity = await repository.GetById(updatedEntity.Id) ?? new Vacancy();

        entity.Title = updatedEntity.Title;
        entity.Content = updatedEntity.Content;
        entity.CompanyId = updatedEntity.CompanyId;

        return await repository.Save(entity);
    }

    public async Task<List<Vacancy>> GetAllFiltered(VacancyFilterDto filters)
    {
        return await repository.GetAllFiltered(filters);
    }
}
