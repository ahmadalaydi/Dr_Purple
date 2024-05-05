using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ContractServiceRepository : BaseRepository<ContractService>, IContractServiceRepository
{
    public ContractServiceRepository(AppDbContext dbContext) : base(dbContext) { }
}
