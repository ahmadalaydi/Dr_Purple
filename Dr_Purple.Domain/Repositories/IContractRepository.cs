using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Repositories;
public interface IContractRepository : IRepository<Contract>
{
    //Task<Contract> GenerateServiceTime(Contract contract);
}