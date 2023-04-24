using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class Payment : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? SubDepartmentId { get; private set; }
    public PaymentType? PaymentType { get; private set; }
    public Status? Status { get; private set; }
    public DateTime Date { get; private set; }
    public float? Amount { get; private set; }
    public SubDepartment? SubDepartment { get; private set; }
    public AppointmentPayment? AppointmentPayment { get; private set; }
    public virtual ICollection<PaymentMaterial>? PaymentMaterials { get; private set; }
    public virtual ICollection<PaymentOffer>? PaymentOffers { get; private set; }
}