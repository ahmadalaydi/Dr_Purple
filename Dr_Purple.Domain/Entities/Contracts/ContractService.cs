using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class ContractService : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public long ContractId { get; private set; }
    public long ServiceId { get; private set; }
    public float Percent { get; private set; }
    public DayOfWeek Day { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    [NotAuditable]
    [JsonIgnore]
    public virtual ICollection<ServiceTime> ServiceTimes { get; private set; } = new HashSet<ServiceTime>();
    [JsonIgnore]
    public virtual Contract? Contract { get; private set; }

    [JsonIgnore]
    public virtual Service? Service { get; private set; }

    public ContractService(long contractId, long serviceId, float percent, DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
    {
        ContractId = contractId;
        ServiceId = serviceId;
        Percent = percent;
        Day = day;
        StartTime = startTime;
        EndTime = endTime;
    }

    public static ContractService Create(long contractId, long serviceId, float percent, DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
        => new(contractId, serviceId, percent, day, startTime, endTime);

    public void Update(long contractId, long serviceId, float percent, DayOfWeek day, TimeSpan startTime, TimeSpan endTime)
    {
        ContractId = contractId;
        ServiceId = serviceId;
        Percent = percent;
        Day = day;
        StartTime = startTime;
        EndTime = endTime;
    }
}