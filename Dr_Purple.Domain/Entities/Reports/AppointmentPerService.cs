using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Reports;
[NotAuditable]
public partial class AppointmentPerService : IEntity
{
    public long Id { get; private set; }
    public long ServiceId { get; private set; }
    public DateOnly Date { get; private set; }
    public int Count { get; private set; }
    public float Total { get; private set; }

    [JsonIgnore]
    public virtual Service? Service { get; private set; }

    protected AppointmentPerService(long serviceId, DateOnly date, int count, float total)
    {
        ServiceId = serviceId;
        Date = date;
        Count = count;
        Total = total;
    }

    public static AppointmentPerService Create(long serviceId, DateOnly date, int count, float total)
        => new(serviceId, date, count, total);
}