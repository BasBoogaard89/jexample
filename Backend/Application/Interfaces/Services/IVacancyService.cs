using Application.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IVacancyService : IBaseService<Vacancy>
{
    Task<List<Vacancy>> GetAllFiltered(VacancyFilterDto filters);
}
