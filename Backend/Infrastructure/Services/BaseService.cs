using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class BaseService<T>(AppDbContext context) : IBaseService<T> where T : BaseEntity
{
    protected readonly AppDbContext _context = context;

    public virtual async Task<List<T>> GetAll()
    {
        return await _context.Set<T>().ToListAsync();
    }
}