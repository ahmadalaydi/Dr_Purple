using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Payments.Base;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class SalePayment : Payment
{
    public long SubDepartmentId { get; private set; }
    public virtual SaleSubDepartment? SubDepartment { get; private set; }
    public virtual ICollection<SalePaymentItem> Items { get; private set; }
    public IPaymentStrategy<SalePayment> Strategy { get; private set; }
    public IPaymentState<SalePayment> State { get; private set; }
    protected internal SalePayment(long subDepartmentId) : base(Guid.NewGuid())
    {
        Items = new HashSet<SalePaymentItem>();
        Strategy = new SalePaymentStrategy();
        State = new NotApprovedSalePaymentState();
        SubDepartmentId = subDepartmentId;
    }

    public static SalePayment Create(long subDepartmentId) => new(subDepartmentId);

    public void Update()
    => State.Update(this);

    protected internal void SetState(IPaymentState<SalePayment> state)
    => State = state;

    public void Approve()
    => State.Approve(this);

    public void DeApprove()
    => State.DeApprove(this);

    public void Calculate()
    => Strategy.CalculateAmount(this);
}