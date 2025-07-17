using Application.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
    Task<List<Company>> GetAllFiltered(CompanyFilterDto filters);
}
