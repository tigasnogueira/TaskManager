using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Infra.Data.Repositories;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
{
    protected readonly TaskManagerContext _context;

    protected Repository(TaskManagerContext context)
    {
        _context = context;
    }

    public virtual async Task<TEntity?> GetById(Guid id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public virtual async Task<IEnumerable<TEntity?>> GetAll()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity?> Add(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public virtual async Task<TEntity?> Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}
