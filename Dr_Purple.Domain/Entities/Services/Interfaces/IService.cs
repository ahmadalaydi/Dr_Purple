using Dr_Purple.Domain.Interfaces;
namespace Dr_Purple.Domain.Entities.Services.Interfaces;
public interface IService : IEntity
{
    static Service Create(long subDepartmentId, string name, float price, TimeSpan duration, string description)
        => Service.Create(subDepartmentId, name, price, duration, description);

    static void Update(long subDepartmentId, string name, float price, TimeSpan duration, string description)
        => Update(subDepartmentId, name, price, duration, description);
}