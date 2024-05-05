using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AppointmentPerServiceRepository : BaseRepository<AppointmentPerService>, IAppointmentPerServiceRepository
{
    public AppointmentPerServiceRepository(AppDbContext dbContext) : base(dbContext) { }
}
