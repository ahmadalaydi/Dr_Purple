namespace Dr_Purple.Domain.Entities.Contracts.ContractStatus;
public class NotActiveContractState : IContractState
{
    public void Active(Contract contract)
    => contract.SetState(new ActiveContractState());
    public void DeActive(Contract contract)
    => throw new NotImplementedException();
}