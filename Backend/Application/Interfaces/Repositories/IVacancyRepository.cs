using Application.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface IVacancyRepository : IBaseRepository<Vacancy>
{
    Task<List<Vacancy>> GetAllFiltered(VacancyFilterDto filters);
}
