using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CompanyService(AppDbContext context) : BaseService<Company>(context), ICompanyService
{
    public override async Task<List<Company>> GetAll()
    {
        return await _context.Companies.ToListAsync();
    }
}
