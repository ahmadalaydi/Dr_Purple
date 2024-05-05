using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Payments.Base;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class NotForSaleOrderPayment : Payment
{
    public long SubDepartmentId { get; private set; }
    public virtual IPaymentStrategy<NotForSaleOrderPayment> Strategy { get; private set; }
    public virtual IPaymentState<NotForSaleOrderPayment> State { get; private set; }
    public ServiceProviderSubDepartment? SubDepartment { get; private set; }
    public virtual ICollection<NotForSaleOrderItem> Items { get; private set; }
    protected internal NotForSaleOrderPayment(long subDepartmentId) : base(Guid.NewGuid())
    {
        SubDepartmentId = subDepartmentId;
        Strategy = new NotForSaleOrderPaymentStrategy();
        State = new NotApprovedNotForSaleOrderPaymentState();
        Items = new HashSet<NotForSaleOrderItem>();
    }
    public static NotForSaleOrderPayment Create(long subDepartmentId)
        => new(subDepartmentId);

    protected internal void SetState(IPaymentState<NotForSaleOrderPayment> state)
    => State = state;
    public void Update()
      => State.Update(this);

    public void Approve()
    => State.Approve(this);

    public void DeApprove()
    => State.DeApprove(this);
}