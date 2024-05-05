using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ContractRepository : BaseRepository<Contract>, IContractRepository
{
    public ContractRepository(AppDbContext dbContext) : base(dbContext) { }
}
