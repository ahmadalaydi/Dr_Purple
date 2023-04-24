using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Additions;
public partial class Addition : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public string? Name { get; private set; }
    public long? ContractId { get; private set; }
    public Contract Contract { get; private set; } = new();
}
