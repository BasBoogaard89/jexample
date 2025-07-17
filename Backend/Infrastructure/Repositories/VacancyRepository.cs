using Application.Dtos.Filters;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class VacancyRepository(AppDbContext context) : BaseRepository<Vacancy>(context), IVacancyRepository
{
    public async Task<List<Vacancy>> GetAllFiltered(VacancyFilterDto filters)
    {
        var filteredData = await context.Vacancies
            .WhereIf(filters.CompanyId != 0, e => e.CompanyId == filters.CompanyId)
            .ToListAsync();

        return filteredData;
    }
}
