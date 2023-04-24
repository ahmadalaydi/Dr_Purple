using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Appointments;
public partial class AppointmentMaterial : IEntity
{
    public int? Id { get; set; }
    public long? AppointmentId { get; private set; }
    public int? MaterialId { get; private set; }
    public float? Quantity { get; private set; }
    public Appointment? Appointment { get; private set; }
    public Material? Material { get; private set; }
}