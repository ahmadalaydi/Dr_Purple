using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Leaves;
public partial class Leave: AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public long? ContractId { get; private set; }
    public LeaveType? LeaveType { get; private set; }
    public Status? Status { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndtDate { get; private set; }
    public float? Duration { get; private set; }
    public Contract? Contract { get; private set; }
}