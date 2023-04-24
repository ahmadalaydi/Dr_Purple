using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class PaymentMaterialRepository : BaseRepository<PaymentMaterial>, IPaymentMaterialRepository
{
    public PaymentMaterialRepository(AppDbContext? dbContext) : base(dbContext) { }
}
