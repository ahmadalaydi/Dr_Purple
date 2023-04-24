using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Orders;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.WareHouses;
public partial class WareHouse : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public string? Name { get; private set; }
    public virtual ICollection<WareHouseMaterial>? WareHouseMaterials { get; private set; }
    public virtual ICollection<Order>? Orders { get; private set; }
}
