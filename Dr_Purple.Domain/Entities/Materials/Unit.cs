using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Materials;
public partial class Unit : AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public string? Name { get; private set; }
    public virtual ICollection<Material>? Materials { get; private set; }
}