using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Orders;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.WareHouses;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Materials;
public partial class Material : AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public string? Name { get; private set; }
    public bool? IsForSale { get; private set; }
    public int? UnitId { get; private set; }
    public Unit? Unit { get; private set; }
    public virtual ICollection<MaterialCostPrice>? MaterialCostPrices { get; private set; }
    public virtual ICollection<MaterialSellPrice>? MaterialSellPrices { get; private set; }
    public virtual ICollection<AppointmentMaterial>? AppointmentMaterials { get; private set; }
    public virtual ICollection<OrderItem>? OrderItems { get; private set; }
    public virtual ICollection<PaymentMaterial>? PaymentMaterials { get; private set; }
    public virtual ICollection<SubDepartmentMaterial>? SubDepartmentMaterials { get; private set; }
    public virtual ICollection<WareHouseMaterial>? WareHouseMaterials { get; private set; }
}