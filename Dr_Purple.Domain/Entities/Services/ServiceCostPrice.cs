using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Services;
public partial class ServiceCostPrice : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? ServiceId { get; private set; }
    public DateTime Date { get; private set; }
    public float? Cost { get; private set; }
    public Service? Service { get; private set; }
}