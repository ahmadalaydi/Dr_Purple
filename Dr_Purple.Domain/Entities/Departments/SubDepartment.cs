using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Orders;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Departments;
public partial class SubDepartment : AuditableEntity,IEntity
{
    public long? Id { get; private set; }
    public string? Name { get; private set; }
    public long? DepartmentId { get; private set; }
    public Department? Department { get; private set; }
    public virtual ICollection<Contract>? Contracts { get; private set; }
    public virtual ICollection<SubDepartmentMaterial>? SubDepartmentMaterials { get; private set; }
    public virtual ICollection<Order>? Orders { get; private set; }
    public virtual ICollection<Payment>? Payments { get; private set; }
    public virtual ICollection<Service>? Services { get; private set; }
}