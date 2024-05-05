namespace Dr_Purple.Domain.Interfaces;
public interface IWriteRepository<T> where T : class, IEntity
{
    Task<T> AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    Task<bool> DeleteAsync(T entity);
    void DeleteRange(IEnumerable<T> entities);
    Task<T> UpdateAsync(T entity);
    Task UpdateRangeAsync(IEnumerable<T> entities);
}