using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Appointments.Interfaces;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Users;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Appointments;
public partial class Appointment : AuditableEntity, IAppointment
{
    public long Id { get; private set; }
    public long UserId { get; private set; }
    public long ServiceTimeId { get; private set; }

    [JsonIgnore]
    public byte[]? RowVersion { get; set; }

    [JsonIgnore]
    public virtual User? User { get; private set; }

    [JsonIgnore]
    [NotAuditable]
    public virtual ServiceTime? ServiceTime { get; private set; }

    [JsonIgnore]
    public virtual AppointmentPayment? AppointmentPayment { get; private set; }

    [JsonIgnore]
    public virtual ICollection<AppointmentMaterial> AppointmentMaterials { get; private set; }

    protected Appointment(long userId, long serviceTimeId)
    {
        UserId = userId;
        ServiceTimeId = serviceTimeId;
        AppointmentMaterials = new HashSet<AppointmentMaterial>();
    }

    public static Appointment Create(long userId, long serviceTimeId)
        => new(userId, serviceTimeId);

    public void Update(long userId, long serviceTimeId)
    {
        UserId = userId;
        ServiceTimeId = serviceTimeId;
    }
    public void CreateAppointmentPayment(AppointmentPayment appointmentPayment)
        => AppointmentPayment = appointmentPayment;
}