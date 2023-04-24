using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class RegionRepository : BaseRepository<Region>, IRegionRepository
{
    public RegionRepository(AppDbContext? dbContext) : base(dbContext) { }
}
