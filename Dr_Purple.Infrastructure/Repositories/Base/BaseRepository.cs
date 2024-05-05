using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Dr_Purple.Infrastructure.Repositories.Base;
public class BaseRepository<T> : IRepository<T> where T : class, IEntity
{
    private readonly DbSet<T> _dbSet;
    public BaseRepository(AppDbContext dbContext)
       => _dbSet = dbContext.Set<T>()!;

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public Task AddRangeAsync(IEnumerable<T> entities)
        => _dbSet.AddRangeAsync(entities);

    public Task<bool> DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
        return Task.FromResult(true);
    }

    public void DeleteRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        => _dbSet!.AnyAsync(predicate);

    public IQueryable<T> GetAll()
        => _dbSet!.AsQueryable().AsNoTracking();

    public IQueryable<T> GetBy(Expression<Func<T, bool>> predicate)
        => _dbSet.Where(predicate);

    public async Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate)
        => await _dbSet.FirstOrDefaultAsync(predicate);

    public Task<T> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        return Task.FromResult(entity);
    }

    public Task UpdateRangeAsync(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
        return Task.FromResult(entities);
    }
}