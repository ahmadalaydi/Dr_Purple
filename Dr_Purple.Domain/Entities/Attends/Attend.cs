using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Attends;
public partial class Attend: AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? ContractId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public Contract? Contract { get; private set; }
}