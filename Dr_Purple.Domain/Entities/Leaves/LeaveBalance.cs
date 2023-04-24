using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Leaves;
public partial class LeaveBalance : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? ContractId { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndtDate { get; private set; }
    public float? Balance { get; private set; }
    public Contract? Contract { get; private set; }
}