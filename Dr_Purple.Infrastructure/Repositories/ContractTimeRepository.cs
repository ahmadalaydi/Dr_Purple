using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ContractTimeRepository : BaseRepository<ContractTime>, IContractTimeRepository
{
    public ContractTimeRepository(AppDbContext? dbContext) : base(dbContext) { }
}
