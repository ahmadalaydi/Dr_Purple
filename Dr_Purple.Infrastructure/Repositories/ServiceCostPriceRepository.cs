using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ServiceCostPriceRepository : BaseRepository<ServiceCostPrice>, IServiceCostPriceRepository
{
    public ServiceCostPriceRepository(AppDbContext? dbContext) : base(dbContext) { }
}
