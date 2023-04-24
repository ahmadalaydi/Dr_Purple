using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Materials;
public partial class MaterialCostPrice : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public int? MaterialId { get; private set; }
    public DateTime Date { get; private set; }
    public float? Price { get; private set; }
    public Material? Material { get; private set; }
}