using Dr_Purple.Domain.Repositories;

namespace Dr_Purple.Domain.Interfaces;
public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
    IRepository<T> Repository<T>() where T : class, IEntity;
    IUserRepository UserRepository { get; }

}