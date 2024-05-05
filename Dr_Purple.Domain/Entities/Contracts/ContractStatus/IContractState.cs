using Dr_Purple.Domain.Entities.Works;

namespace Dr_Purple.Domain.Entities.Contracts.ContractStatus;
public interface IContractState
{
    public abstract void Active(Contract contract);
    public abstract void DeActive(Contract contract);
}