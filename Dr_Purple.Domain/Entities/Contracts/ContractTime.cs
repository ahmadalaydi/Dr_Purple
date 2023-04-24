using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class ContractTime : IEntity
{
    public long? Id { get; private set; }
    public long? ContractServiceId { get; private set; }
    public DayOfWeek Day { get; private set;}
    public TimeOnly StartTime { get; private set; }
    public TimeOnly EndTime { get; private set;}
    public ContractService? ContractService { get; private set; }
}