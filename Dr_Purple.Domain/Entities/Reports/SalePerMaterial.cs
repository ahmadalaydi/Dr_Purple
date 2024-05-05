using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Reports;
[NotAuditable]
public partial class SalePerMaterial : IEntity
{
    public long Id { get; private set; }
    public long MaterialId { get; private set; }
    public DateOnly Date { get; private set; }
    public float Count { get; private set; }
    public float Total { get; private set; }

    [JsonIgnore]
    public virtual ForSaleMaterial? Material { get; private set; }

    protected SalePerMaterial(long materialId, DateOnly date, float count, float total)
    {
        MaterialId = materialId;
        Date = date;
        Count = count;
        Total = total;
    }

    public static SalePerMaterial Create(long materialId, DateOnly date, float count, float total)
        => new(materialId, date, count, total);
}