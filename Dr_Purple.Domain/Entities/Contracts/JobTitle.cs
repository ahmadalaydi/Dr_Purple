using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
[NotAuditable]
public class JobTitle : IEntity
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<Contract> Contracts { get; private set; } = new HashSet<Contract>();

    public JobTitle(string name)
        => Name = name;
    public static JobTitle Create(string name)
        => new(name);

    public void Update(string name)
        => Name = name;
}