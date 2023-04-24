using Dr_Purple.Domain.Entities.WareHouses;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class WareHouseMaterialRepository : BaseRepository<WareHouseMaterial>, IWareHouseMaterialRepository
{
    public WareHouseMaterialRepository(AppDbContext? dbContext) : base(dbContext) { }
}
