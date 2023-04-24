using Dr_Purple.Domain.Entities.Offers;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class OfferRepository : BaseRepository<Offer>, IOfferRepository
{
    public OfferRepository(AppDbContext? dbContext) : base(dbContext) { }
}
