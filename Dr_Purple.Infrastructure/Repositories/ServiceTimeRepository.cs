using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ServiceTimeRepository : BaseRepository<ServiceTime>, IServiceTimeRepository
{
    public ServiceTimeRepository(AppDbContext? dbContext) : base(dbContext) { }
}
