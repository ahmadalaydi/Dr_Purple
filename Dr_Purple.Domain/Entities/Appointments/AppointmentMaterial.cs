using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Appointments;
[NotAuditable]
public partial class AppointmentMaterial : IEntity
{
    public long Id { get; private set; }
    public long AppointmentId { get; private set; }
    public long MaterialId { get; private set; }
    public float Quantity { get; private set; }

    [JsonIgnore]
    public virtual Appointment? Appointment { get; private set; }

    [JsonIgnore]
    public virtual NotForSaleMaterial? Material { get; private set; }

    protected AppointmentMaterial(long appointmentId, long materialId, float quantity)
    {
        AppointmentId = appointmentId;
        MaterialId = materialId;
        Quantity = quantity;
    }

    public static AppointmentMaterial Create(long appointmentId, long materialId, float quantity)
        => new(appointmentId, materialId, quantity);

    public void Update(long materialId, float quantity)
    {
        MaterialId = materialId;
        Quantity = quantity;
    }
}