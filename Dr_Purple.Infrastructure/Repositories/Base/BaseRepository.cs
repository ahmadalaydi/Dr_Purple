using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dr_Purple.Infrastructure.Repositories.Base;
public class BaseRepository<T> : IRepository<T> where T :class, IEntity
{
    private readonly DbSet<T>? _dbSet;
    public BaseRepository(AppDbContext? dbContext)
    {
        _dbSet = dbContext!.Set<T>();
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet!.AddAsync(entity);
        return entity;
    }


    public Task AddRangeAsync(IEnumerable<T> entities)
    {
        return _dbSet!.AddRangeAsync(entities);
    }

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet!.Remove(entity);
        return Task.FromResult(true);

    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet!.RemoveRange(entities);
    }


    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet!.AnyAsync(predicate);
    }

    public IQueryable<T> GetAll()
    {
        return GetEntities()!;
    }

    public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
    {
        return GetEntities()!.Where(predicate);
    }

    public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await GetEntities()!.FirstOrDefaultAsync(predicate);
    }

    public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
    {
        return await GetEntities()!.SingleOrDefaultAsync(predicate)!;
    }

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet!.Update(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet!.UpdateRange(entities);
        return Task.FromResult(entities);
    }

    private IQueryable<T>? GetEntities(bool asNoTracking = true)
    {
        if (asNoTracking)
            return _dbSet!.AsNoTracking();
        return _dbSet;
    }
}