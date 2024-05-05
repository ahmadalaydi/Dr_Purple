using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class Addition : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public long ContractId { get; private set; }
    public string Name { get; private set; } = string.Empty;

    [JsonIgnore]
    public virtual Contract? Contract { get; private set; }

    private protected Addition(string name, long contractId)
    {
        Name = name;
        ContractId = contractId;
    }

    public static Addition Create(string name, long contractId)
        => new(name, contractId);

    public void Update(string name, long contractId)
    {
        Name = name;
        ContractId = contractId;
    }
}