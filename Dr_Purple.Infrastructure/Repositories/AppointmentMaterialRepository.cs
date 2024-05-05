using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AppointmentMaterialRepository : BaseRepository<AppointmentMaterial>, IAppointmentMaterialRepository
{
    public AppointmentMaterialRepository(AppDbContext dbContext) : base(dbContext) { }
}
