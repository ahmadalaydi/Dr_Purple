using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Services;

namespace Dr_Purple.Domain.Entities.Departments;
public partial class ServiceProviderSubDepartment : SubDepartment
{
    public virtual ICollection<Service> Services { get; private set; }
    public virtual ICollection<NotForSaleOrderPayment> OrderPayments { get; private set; }
    public virtual ICollection<AppointmentPayment> AppointmentPayments { get; private set; }
    public virtual ICollection<ServiceProviderSubDepartmentMaterial> Materials { get; private set; }

    protected ServiceProviderSubDepartment(string name, long departmentId) : base(name, departmentId)
    {
        Services = new HashSet<Service>();
        AppointmentPayments = new HashSet<AppointmentPayment>();
        OrderPayments = new HashSet<NotForSaleOrderPayment>();
        Materials = new HashSet<ServiceProviderSubDepartmentMaterial>();
    }
    public static ServiceProviderSubDepartment Create(string name, long departmentId)
        => new(name, departmentId);
}