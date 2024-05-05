using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AppointmentPerContractRepository : BaseRepository<AppointmentPerContract>, IAppointmentPerContractRepository
{
    public AppointmentPerContractRepository(AppDbContext dbContext) : base(dbContext) { }
}
