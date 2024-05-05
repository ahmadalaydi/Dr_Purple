using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Departments.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Departments.Base;
public abstract class SubDepartment : AuditableEntity, ISubDepartment
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public long DepartmentId { get; private set; }

    [JsonIgnore]
    public virtual Department? Department { get; private set; }


    protected SubDepartment(string name, long departmentId)
    {
        Name = name;
        DepartmentId = departmentId;
    }

    public void Update(string name, long departmentId)
    {
        Name = name;
        DepartmentId = departmentId;
    }
}