using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Departments.Interfaces;
public interface IDepartment : IEntity
{
    static Department Create(string name)
        => Department.Create(name);

    void Update(string name)
    {
        Update(name);
    }
}