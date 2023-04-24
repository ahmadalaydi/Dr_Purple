using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Departments;
public partial class SubDepartmentMaterial:IEntity
{
    public int? Id { get; private set; }
    public long? SubDepartmentId { get; private set; }
    public int? MaterialId { get; private set; }
    public float? Quantity { get; private set; }
    public SubDepartment? SubDepartment { get; private set; }
    public Material? Material { get; private set; }
}