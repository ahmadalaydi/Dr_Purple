using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Reports;
[NotAuditable]
public partial class SalaryPerContract : IEntity
{
    public long Id { get; private set; }
    public long ContractId { get; private set; }
    public DateOnly Date { get; private set; }
    public int Count { get; private set; }
    public float Total { get; private set; }

    [JsonIgnore]
    public virtual Contract? Contract { get; private set; }

    protected SalaryPerContract(long contractId, DateOnly date, int count, float total)
    {
        ContractId = contractId;
        Date = date;
        Count = count;
        Total = total;
    }

    public static SalaryPerContract Create(long contractId, DateOnly date, int count, float total)
        => new(contractId, date, count, total);
}