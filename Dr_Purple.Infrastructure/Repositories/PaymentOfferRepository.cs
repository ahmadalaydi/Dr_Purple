using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class PaymentOfferRepository : BaseRepository<PaymentOffer>, IPaymentOfferRepository
{
    public PaymentOfferRepository(AppDbContext? dbContext) : base(dbContext) { }
}
