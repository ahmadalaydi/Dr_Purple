using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Contracts;
public partial class Attend : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public long ContractId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }

    [JsonIgnore]
    public virtual Contract? Contract { get; private set; }

    protected Attend(long contractId, DateTime startDate, DateTime endDate)
    {
        ContractId = contractId;
        StartDate = startDate;
        EndDate = endDate;
    }
    public static Attend Create(long contractId, DateTime startDate, DateTime endDate)
        => new(contractId, startDate, endDate);

    public void Update(long contractId, DateTime startDate, DateTime endDate)
    {
        ContractId = contractId;
        StartDate = startDate;
        EndDate = endDate;
    }
}