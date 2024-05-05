using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Payments.Base;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class AppointmentPayment : Payment
{
    public long AppointmentId { get; private set; }
    public long SubDepartmentId { get; private set; }
    public virtual ServiceProviderSubDepartment? SubDepartment { get; private set; }
    public virtual Appointment? Appointment { get; private set; }
    public IPaymentStrategy<AppointmentPayment> Strategy { get; private set; }
    public IPaymentState<AppointmentPayment> State { get; private set; }

    protected internal AppointmentPayment(long appointmentId, long subDepartmentId) : base(Guid.NewGuid())
    {
        AppointmentId = appointmentId;
        SubDepartmentId = subDepartmentId;
        Strategy = new AppointmentPaymentStrategy();
        State = new NotApprovedAppointmentPaymentState();
    }

    public static AppointmentPayment CreateAppointmentPayment(long appointmentId, long subDepartmentId)
    => new(appointmentId, subDepartmentId);

    public void Update()
    => State.Update(this);

    protected internal void SetState(IPaymentState<AppointmentPayment> state)
    => State = state;

    public void Approve()
    => State.Approve(this);

    public void DeApprove()
    => State.DeApprove(this);
}