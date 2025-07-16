using Domain.Entities;

namespace Infrastructure.Interfaces.Repositories;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAll();
}
