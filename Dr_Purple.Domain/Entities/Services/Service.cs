using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Services;
public partial class Service: AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? SubDepartmentId { get; private set; }
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public SubDepartment? SubDepartment { get; private set; }
    public virtual ICollection<ServiceTime>? ServiceTimes { get; private set; }
    public virtual ICollection<ServiceCostPrice>? ServiceCostPrices { get; private set; }
    public virtual ICollection<ContractService>? ContractServices { get; private set; }
}