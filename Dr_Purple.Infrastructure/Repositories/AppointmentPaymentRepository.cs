using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AppointmentPaymentRepository : BaseRepository<AppointmentPayment>, IAppointmentPaymentRepository
{
    public AppointmentPaymentRepository(AppDbContext dbContext) : base(dbContext) { }
}
