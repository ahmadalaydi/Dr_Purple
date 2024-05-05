using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Works;
public partial class WorkHoursException : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    protected WorkHoursException(string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
    public static WorkHoursException Create(string name, DateTime startDate, DateTime endDate)
        => new(name, startDate, endDate);

    public void Update(string name, DateTime startDate, DateTime endDate)
    {
        Name = name;
        StartDate = startDate;
        EndDate = endDate;
    }
}
