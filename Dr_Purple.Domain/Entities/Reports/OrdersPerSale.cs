using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Reports;
[NotAuditable]
public partial class OrdersPerSale : IEntity
{
    public long Id { get; private set; }
    public long SubDepartmentId { get; private set; }
    public DateOnly Date { get; private set; }
    public int Count { get; private set; }
    public float Total { get; private set; }

    [JsonIgnore]
    public virtual SaleSubDepartment? SubDepartment { get; private set; }

    protected OrdersPerSale(long subDepartmentId, DateOnly date, int count, float total)
    {
        SubDepartmentId = subDepartmentId;
        Date = date;
        Count = count;
        Total = total;
    }

    public static OrdersPerSale Create(long subDepartmentId, DateOnly date, int count, float total)
        => new(subDepartmentId, date, count, total);
}