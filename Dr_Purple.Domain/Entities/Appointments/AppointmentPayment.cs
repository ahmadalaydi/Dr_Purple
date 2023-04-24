using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Appointments;
public partial class AppointmentPayment : IEntity
{
    public long? AppointmentId { get; private set; }
    public long? PaymentId { get; private set; }
    public Appointment? Appointment { get; private set; }
    public Payment? Payment { get; private set; }
}