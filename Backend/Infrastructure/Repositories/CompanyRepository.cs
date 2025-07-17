using Application.Dtos.Filters;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CompanyRepository(AppDbContext context) : BaseRepository<Company>(context), ICompanyRepository
{
    public async Task<List<Company>> GetAllFiltered(CompanyFilterDto filters)
    {
        var filteredData = await context.Companies
            .WhereIf(filters.OnlyWithActiveVacancies, c => c.Vacancies.Count > 0)
            .ToListAsync();

        return filteredData;
    }
}
