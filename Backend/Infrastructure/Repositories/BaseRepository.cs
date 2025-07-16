using Domain.Entities;
using Infrastructure.Context;
using Infrastructure.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }

    public Task<List<T>> GetAll()
    {
        return _context.Set<T>().ToListAsync();
    }
}
