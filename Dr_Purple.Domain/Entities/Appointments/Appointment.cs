using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Appointments;
public partial class Appointment : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? UserId { get; private set; }
    public User? User { get; private set; }
    public AppointmentServiceTime? AppointmentServiceTime { get; private set; }
    public AppointmentPayment? AppointmentPayment { get; private set; }
    public virtual ICollection<AppointmentMaterial>? AppointmentMaterials { get; private set; }
}