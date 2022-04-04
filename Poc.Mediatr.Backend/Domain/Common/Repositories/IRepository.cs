using Domain.Common.Entities;

namespace Domain.Common.Repositories;

public interface IRepository<T> where T : RootEntity
{
    Task<RootEntity> GetByIdAsync(Guid id);
    Task Create(T entity);
}