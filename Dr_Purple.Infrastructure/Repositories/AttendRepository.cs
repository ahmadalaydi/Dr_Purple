using Dr_Purple.Domain.Entities.Attends;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AttendRepository : BaseRepository<Attend>, IAttendRepository
{
    public AttendRepository(AppDbContext? dbContext) : base(dbContext) { }
}
