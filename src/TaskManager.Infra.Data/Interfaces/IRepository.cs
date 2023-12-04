using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Interfaces;

public interface IRepository<TEntity> : IDisposable where TEntity : Entity, new()
{
    Task<TEntity?> GetById(Guid id);
    Task<IEnumerable<TEntity?>> GetAll();
    Task<TEntity?> Add(TEntity entity);
    Task<TEntity?> Update(TEntity entity);
    Task<TEntity?> Remove(TEntity entity);
}
