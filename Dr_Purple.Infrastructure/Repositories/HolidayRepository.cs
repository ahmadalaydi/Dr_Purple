using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class HolidayRepository : BaseRepository<Holiday>, IHolidayRepository
{
    public HolidayRepository(AppDbContext dbContext) : base(dbContext) { }
}