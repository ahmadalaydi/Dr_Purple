namespace Dr_Purple.Domain.Entities.Payments.State;
public class ApprovedAppointmentPaymentState : IPaymentState<AppointmentPayment>
{
    public void Approve(AppointmentPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void DeApprove(AppointmentPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Delete(AppointmentPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Update(AppointmentPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Add(AppointmentPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");
}