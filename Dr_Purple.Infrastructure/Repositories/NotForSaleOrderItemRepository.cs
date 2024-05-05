using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class NotForSaleOrderItemRepository : BaseRepository<NotForSaleOrderItem>, INotForSaleOrderItemRepository
{
    public NotForSaleOrderItemRepository(AppDbContext dbContext) : base(dbContext) { }
}
