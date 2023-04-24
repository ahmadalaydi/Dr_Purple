using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Orders;
public partial class OrderItem : AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public int? MaterialId { get; private set; }
    public long? OrderId { get; private set; }
    public float? Quantity { get; private set; }
    public Material? Material { get; private set; }
    public Order? Order { get; private set; }
}