using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Departments.Interfaces;
using Dr_Purple.Domain.Entities.Materials;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Departments;
[NotAuditable]
public partial class SaleSubDepartmentMaterial : ISubDepartmentMaterial
{
    public long Id { get; private set; }
    public long SubDepartmentId { get; private set; }
    public long MaterialId { get; private set; }
    public float Quantity { get; private set; }
    [JsonIgnore]
    public virtual SaleSubDepartment? SubDepartment { get; private set; }
    public virtual ForSaleMaterial? Material { get; private set; }
    protected SaleSubDepartmentMaterial(long subDepartmentId, long materialId, float quantity)
    {
        SubDepartmentId = subDepartmentId;
        MaterialId = materialId;
        Quantity = quantity;
    }

    public static SaleSubDepartmentMaterial Create(long subDepartmentId, long materialId, float quantity)
        => new(subDepartmentId, materialId, quantity);

    internal void MinQuantity(float quantity) => Quantity -= quantity;

    internal void AddQuantity(float quantity) => Quantity += quantity;
}