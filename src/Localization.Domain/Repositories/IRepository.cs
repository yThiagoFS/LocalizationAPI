using Localization.Domain.Entities;

namespace Localization.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task Add(T entity);

    Task<IEnumerable<T>> GetAll();

    Task<T> GetById(Guid id);

    Task Update(T entity);

    Task Remove(Guid id);
}