using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext dbContext) : base(dbContext) { }
}
