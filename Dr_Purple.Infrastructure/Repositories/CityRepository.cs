using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class CityRepository : BaseRepository<City>, ICityRepository
{
    public CityRepository(AppDbContext? dbContext) : base(dbContext) { }
}
