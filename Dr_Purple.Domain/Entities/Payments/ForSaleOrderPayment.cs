using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Payments.Base;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class ForSaleOrderPayment : Payment
{
    public long SubDepartmentId { get; private set; }
    public virtual IPaymentStrategy<ForSaleOrderPayment> Strategy { get; private set; }
    public virtual IPaymentState<ForSaleOrderPayment> State { get; private set; }
    public virtual ICollection<ForSaleOrderItem> Items { get; private set; }
    public SaleSubDepartment? SubDepartment { get; private set; }

    protected internal ForSaleOrderPayment(long subDepartmentId) : base(Guid.NewGuid())
    {
        SubDepartmentId = subDepartmentId;
        Strategy = new ForSaleOrderPaymentStrategy();
        State = new NotApprovedForSaleOrderPaymentState();
        Items = new HashSet<ForSaleOrderItem>();
    }
    public static ForSaleOrderPayment Create(long subDepartmentId)
        => new(subDepartmentId);

    public void Update()
      => State.Update(this);

    protected internal void SetState(IPaymentState<ForSaleOrderPayment> state)
    => State = state;

    public void Approve()
    => State.Approve(this);

    public void DeApprove()
    => State.DeApprove(this);
}