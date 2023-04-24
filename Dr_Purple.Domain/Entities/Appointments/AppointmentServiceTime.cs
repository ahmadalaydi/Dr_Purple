using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Appointments;
public partial class AppointmentServiceTime : AuditableEntity, IEntity
{
    public long? ServiceTimeId { get; private set; }
    public long? AppointmentId { get; private set; }
    public Appointment? Appointment { get; private set; }
    public ServiceTime? ServiceTime { get; private set; }
}