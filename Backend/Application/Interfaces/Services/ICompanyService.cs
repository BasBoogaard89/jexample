using Application.Dtos.Filters;
using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICompanyService : IBaseService<Company>
{
    Task<List<Company>> GetAllFiltered(CompanyFilterDto filters);
}
