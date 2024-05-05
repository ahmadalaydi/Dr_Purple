using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Works;
public partial class Holiday : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateOnly Date { get; private set; }

    protected Holiday(string name, DateOnly date)
    {
        Name = name;
        Date = date;
    }

    public static Holiday Create(string name, DateOnly date)
        => new(name, date);

    public void Update(string name, DateOnly date)
    {
        Name = name;
        Date = date;
    }
}
