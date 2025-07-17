using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Domain.Entities;

namespace Infrastructure.Services;

public class BaseService<T>(IBaseRepository<T> repository) : IBaseService<T> where T : BaseEntity
{
    public virtual async Task<List<T>> GetAll()
    {
        return await repository.GetAll();
    }

    public virtual async Task<T> GetById(int id)
    {
        return await repository.GetById(id);
    }

    public virtual async Task<T> Save(T entity)
    {
        return await repository.Save(entity);
    }

    public virtual async Task<bool> Delete(int id)
    {
        var entity = await GetById(id);

        if (entity == null)
            return false;

        await repository.Delete(id);

        return true;
    }
}