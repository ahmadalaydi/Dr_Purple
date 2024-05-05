using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Materials.Base;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Reports;

namespace Dr_Purple.Domain.Entities.Materials;
public partial class ForSaleMaterial : Material
{
    public float SalePrice { get; private set; }
    [NotAuditable]
    public virtual ICollection<SalePerMaterial> SellsPerMaterial { get; private set; }
    [NotAuditable]
    public virtual ICollection<SaleSubDepartmentMaterial> SubDepartmentMaterials { get; private set; }
    [NotAuditable]
    public virtual ICollection<ForSaleOrderItem> Items { get; private set; }

    protected internal ForSaleMaterial(string name, string unit, float costPrice, float salePrice) : base(name, unit, costPrice)
    {
        SalePrice = salePrice;
        SellsPerMaterial = new HashSet<SalePerMaterial>();
        SubDepartmentMaterials = new HashSet<SaleSubDepartmentMaterial>();
        Items = new HashSet<ForSaleOrderItem>();
    }

    public static ForSaleMaterial Create(string name, string unit, float costPrice, float salePrice)
        => new(name, unit, costPrice, salePrice);

    public void Update(string name, string unit, float costPrice, float salePrice)
    {
        Update(name, unit, costPrice);
        SalePrice = salePrice;
    }
}