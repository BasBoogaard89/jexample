using Domain.Entities;

namespace Infrastructure.Interfaces.Services;

public interface IBaseService<T> where T : BaseEntity
{
    Task<List<T>> GetAll();
}