namespace Dr_Purple.Domain.Entities.Contracts.ContractStatus;
public class ActiveContractState : IContractState
{
    public void Active(Contract contract)
    => throw new NotImplementedException();

    public void DeActive(Contract contract)
    => contract.SetState(new NotActiveContractState());
}