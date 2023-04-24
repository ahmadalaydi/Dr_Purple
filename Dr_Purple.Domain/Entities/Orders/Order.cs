using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.WareHouses;
using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Orders;
public partial class Order : AuditableEntity, IEntity
{
    public long? Id { get; private set; }
    public long? SubDepartmentId { get; private set; }
    public long? WareHouseId { get; private set; }
    public Status? Status { get; private set; }
    public DateTime Date { get; private set; }
    public SubDepartment? SubDepartment { get; private set; }
    public WareHouse? WareHouse { get; private set; }
    public virtual ICollection<OrderItem>? OrderItems { get; private set; }
}