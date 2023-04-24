using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class ContractService : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? ContractId { get; private set; }
    public long? ServiceId { get; private set; }
    public Contract? Contract { get; private set; }
    public Service? Service { get; private set; }
    public virtual ICollection<ContractTime>? ContractTimes { get; private set; }
}