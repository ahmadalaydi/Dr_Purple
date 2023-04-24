using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class MaterialCostPriceRepository : BaseRepository<MaterialCostPrice>, IMaterialCostPriceRepository
{
    public MaterialCostPriceRepository(AppDbContext? dbContext) : base(dbContext) { }
}
