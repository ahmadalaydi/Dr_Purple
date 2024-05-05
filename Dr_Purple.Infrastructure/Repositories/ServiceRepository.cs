using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ServiceRepository : BaseRepository<Service>, IServiceRepository
{
    public ServiceRepository(AppDbContext dbContext) : base(dbContext) { }
}
