using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Services;
public class ServiceTime : IEntity
{
    public long? Id { get; private set; }
    public long? ServiceId { get; private set; }
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set; }
    public Service? Service { get; private set; }
    public AppointmentServiceTime? AppointmentServiceTime { get; private set; }
}