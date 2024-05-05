using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts.ContractStatus;
using Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class Leave : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public long ContractId { get; private set; }
    public ILeaveState State { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public TimeSpan Duration { get; private set; }

    [JsonIgnore]
    public virtual Contract? Contract { get; private set; }

    protected Leave(long contractId, DateTime startDate, DateTime endDate)
    {
        ContractId = contractId;
        State = new NotApprovedLeaveState();
        StartDate = startDate;
        EndDate = endDate;
        Duration = endDate.Subtract(startDate);
    }

    public static Leave Create(long contractId, DateTime startDate, DateTime endDate)
        => new(contractId, startDate, endDate);

    public void Update(long contractId, DateTime startDate, DateTime endDate)
    {
        ContractId = contractId;
        StartDate = startDate;
        EndDate = endDate;
        Duration = endDate.Subtract(startDate);
    }
    protected internal void SetState(ILeaveState state)
    => State = state;
}