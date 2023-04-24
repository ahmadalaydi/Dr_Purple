using Dr_Purple.Domain.Entities.Additions;
using Dr_Purple.Domain.Entities.Attends;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Leaves;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class Contract : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? UserId { get; private set; }
    public long? SubDepartmentId { get; private set; }
    public float? Salary { get; private set; }
    public DateOnly StartDate { get; private set; }
    public DateOnly EndtDate { get; private set; }
    public bool IsActive { get; private set; }
    public User? User { get; private set; }
    public SubDepartment? SubDepartment { get; private set; }
    public virtual ICollection<ContractService>? ContractServices { get; private set; }
    public virtual ICollection<Addition>? Additions { get; private set; }
    public virtual ICollection<Leave>? Leaves { get; private set; }
    public virtual ICollection<Attend>? Attends { get; private set; }
    public virtual ICollection<LeaveBalance>? LeaveBalances { get; private set; }
}