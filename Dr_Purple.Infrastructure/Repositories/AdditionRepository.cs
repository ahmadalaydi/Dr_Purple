using Dr_Purple.Domain.Entities.Additions;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AdditionRepository : BaseRepository<Addition>, IAdditionRepository
{
    public AdditionRepository(AppDbContext? dbContext) : base(dbContext) { }
}
