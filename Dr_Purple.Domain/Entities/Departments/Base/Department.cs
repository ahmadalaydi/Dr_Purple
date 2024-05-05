using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Departments.Interfaces;

namespace Dr_Purple.Domain.Entities.Departments.Base;
public partial class Department : AuditableEntity, IDepartment
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public virtual ICollection<SubDepartment> SubDepartments { get; private set; }
    public virtual ICollection<Contract> Contracts { get; private set; }

    protected Department(string name)
    {
        Name = name;
        SubDepartments = new HashSet<SubDepartment>();
        Contracts = new HashSet<Contract>();
    }

    public static Department Create(string name)
    => new(name);

    public void Update(string name)
    => Name = name;
}