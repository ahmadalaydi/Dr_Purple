using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Entities.Services.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Services;
public partial class Service : AuditableEntity, IService
{
    public long Id { get; private set; }
    public long SubDepartmentId { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public float Price { get; private set; }
    public TimeSpan Duration { get; private set; }
    public string Description { get; private set; } = string.Empty;

    [JsonIgnore]
    public ServiceProviderSubDepartment? SubDepartment { get; private set; }

    [NotAuditable]
    public virtual ICollection<ServiceTime> ServiceTimes { get; private set; }

    public virtual ICollection<ContractService> ContractServices { get; private set; }

    public virtual ICollection<AppointmentPerService> AppointmentsPerService { get; private set; }

    protected Service(long subDepartmentId, string name, float price, TimeSpan duration, string description)
    {
        SubDepartmentId = subDepartmentId;
        Name = name;
        Price = price;
        Duration = duration;
        Description = description;
        ServiceTimes = new HashSet<ServiceTime>();
        ContractServices = new HashSet<ContractService>();
        AppointmentsPerService = new HashSet<AppointmentPerService>();
    }

    internal static Service Create(long subDepartmentId, string name, float price, TimeSpan duration, string description)
            => new(subDepartmentId, name, price, duration, description);

    public void Update(long subDepartmentId, string name, float price, TimeSpan duration, string description)
    {
        SubDepartmentId = subDepartmentId;
        Name = name;
        Price = price;
        Duration = duration;
        Description = description;
    }
}