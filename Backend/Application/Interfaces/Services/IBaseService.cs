using Domain.Entities;

namespace Application.Interfaces.Services;

public interface IBaseService<T> where T : BaseEntity
{
    Task<List<T>> GetAll();
    Task<T> GetById(int id);
    Task<T> Save(T entity);
    Task<bool> Delete(int id);
}