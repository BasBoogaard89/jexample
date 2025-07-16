using Domain.Entities;

namespace Application.Interfaces.Services;

public interface ICompanyService : IBaseService<Company>
{
    Task<Company> Save(Company entity);
}
