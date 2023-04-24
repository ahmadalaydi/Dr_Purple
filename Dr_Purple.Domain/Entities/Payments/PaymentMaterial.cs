using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class PaymentMaterial : AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public long? PaymentId { get; private set; }
    public int? MaterialId { get; private set; }
    public float? Quantity { get; private set; }
    public Material? Material { get; private set; }
    public Payment? Payment { get; private set; }
}