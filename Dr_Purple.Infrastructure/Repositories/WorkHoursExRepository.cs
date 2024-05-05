using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class WorkHoursExceptionRepository : BaseRepository<WorkHoursException>, IWorkHoursExceptionRepository
{
    public WorkHoursExceptionRepository(AppDbContext dbContext) : base(dbContext) { }
}