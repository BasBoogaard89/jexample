using Domain.Entities;
using Infrastructure.Context;
using Application.Interfaces.Repositories;

namespace Infrastructure.Repositories;

public class CompanyRepository(AppDbContext context) : BaseRepository<Company>(context), ICompanyRepository
{
}
