using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Materials.Base;
using Dr_Purple.Domain.Entities.Payments;

namespace Dr_Purple.Domain.Entities.Materials;
public partial class NotForSaleMaterial : Material
{
    public virtual ICollection<AppointmentMaterial> AppointmentMaterials { get; private set; }
    public virtual ICollection<ServiceProviderSubDepartmentMaterial> SubDepartmentMaterials { get; private set; }
    public virtual ICollection<NotForSaleOrderItem> Items { get; private set; }

    protected internal NotForSaleMaterial(string name, string unit, float costPrice) : base(name, unit, costPrice)
    {
        AppointmentMaterials = new HashSet<AppointmentMaterial>();
        SubDepartmentMaterials = new HashSet<ServiceProviderSubDepartmentMaterial>();
        Items = new HashSet<NotForSaleOrderItem>();
    }

    public static NotForSaleMaterial Create(string name, string unit, float costPrice)
        => new(name, unit, costPrice);
}