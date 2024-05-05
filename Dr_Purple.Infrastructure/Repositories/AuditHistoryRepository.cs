using Dr_Purple.Domain.Entities.Auditing;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AuditHistoryRepository : BaseRepository<AuditHistory>, IAuditHistoryRepository
{
    public AuditHistoryRepository(AppDbContext dbContext) : base(dbContext) { }
}
