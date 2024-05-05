using System.Linq.Expressions;

namespace Dr_Purple.Domain.Interfaces;
public interface IReadRepository<T> where T : class, IEntity
{
    Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
    IQueryable<T> GetAll();
    IQueryable<T> GetBy(Expression<Func<T, bool>> predicate);
    Task<T> GetFirstAsync(Expression<Func<T, bool>> predicate);
}