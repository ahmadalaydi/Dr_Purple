using Dr_Purple.Domain.Entities.WareHouses;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class WareHouseRepository : BaseRepository<WareHouse>, IWareHouseRepository
{
    public WareHouseRepository(AppDbContext? dbContext) : base(dbContext) { }
}
