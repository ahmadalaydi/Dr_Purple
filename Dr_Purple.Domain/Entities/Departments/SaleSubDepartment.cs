using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Entities.Payments;

namespace Dr_Purple.Domain.Entities.Departments;
public partial class SaleSubDepartment : SubDepartment
{
    public virtual ICollection<SaleSubDepartmentMaterial> Materials { get; private set; }
    public virtual ICollection<ForSaleOrderPayment> OrderPayments { get; private set; }
    public virtual ICollection<SalePayment> SalePayments { get; private set; }

    protected SaleSubDepartment(string name, long departmentId) : base(name, departmentId)
    {
        Materials = new HashSet<SaleSubDepartmentMaterial>();
        OrderPayments = new HashSet<ForSaleOrderPayment>();
        SalePayments = new HashSet<SalePayment>();
    }
    public static SaleSubDepartment Create(string name, long departmentId)
        => new(name, departmentId);
}