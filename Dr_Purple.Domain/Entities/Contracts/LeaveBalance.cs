using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class LeaveBalance : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public long ContractId { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndDate { get; private set; }
    public float Balance { get; private set; }

    [JsonIgnore]
    public virtual Contract? Contract { get; private set; }

    protected LeaveBalance(long contractId, DateOnly startDate, DateOnly endDate, float balance)
    {
        ContractId = contractId;
        StartDate = startDate;
        EndDate = endDate;
        Balance = balance;
    }

    public static LeaveBalance Create(long contractId, DateOnly startDate, DateOnly endDate, float balance)
        => new(contractId, startDate, endDate, balance);

    public void Update(long contractId, DateOnly startDate, DateOnly endDate, float balance)
    {
        ContractId = contractId;
        StartDate = startDate;
        EndDate = endDate;
        Balance = balance;
    }
}