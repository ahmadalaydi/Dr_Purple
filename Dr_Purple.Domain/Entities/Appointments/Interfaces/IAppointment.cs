using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Appointments.Interfaces;
public interface IAppointment : IEntity
{
    static Appointment Create(long userId, long serviceTimeId)
        => Appointment.Create(userId, serviceTimeId);
}