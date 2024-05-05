using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Departments.Interfaces;
public interface ISubDepartment : IEntity
{
    static SubDepartment Create(string name)
        => Create(name);

    void Update(string name)
    {
        Update(name);
    }
}