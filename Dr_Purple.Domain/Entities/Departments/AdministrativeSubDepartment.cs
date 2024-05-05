using Dr_Purple.Domain.Entities.Departments.Base;

namespace Dr_Purple.Domain.Entities.Departments;
public partial class AdministrativeSubDepartment : SubDepartment
{
    protected AdministrativeSubDepartment(string name, long departmentId) : base(name, departmentId) { }

    public static AdministrativeSubDepartment Create(string name, long departmentId)
        => new(name, departmentId);
}