using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Departments;
public partial class Department : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public string? Name { get; private set; }
    public virtual ICollection<SubDepartment>? SubDepartments { get; private set; }
}
