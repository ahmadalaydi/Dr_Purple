using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class NotForSaleMaterialRepository : BaseRepository<NotForSaleMaterial>, INotForSaleMaterialRepository
{
    public NotForSaleMaterialRepository(AppDbContext dbContext) : base(dbContext) { }
}
