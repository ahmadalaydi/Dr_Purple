using Dr_Purple.Domain.Entities.Departments.Base;

namespace Dr_Purple.Domain.Entities.Payments.State;
public class NotApprovedAppointmentPaymentState : IPaymentState<AppointmentPayment>
{
    public void Approve(AppointmentPayment payment)
    {
        foreach (var item in payment.Appointment!.AppointmentMaterials!)
        {
            var material = payment!.SubDepartment!.Materials!
                .FirstOrDefault(_ => _.MaterialId.Equals(item.MaterialId));

            material!.MinQuantity(item.Quantity);
        }
        payment.SetState(new ApprovedAppointmentPaymentState());
    }

    public void DeApprove(AppointmentPayment payment)
    => throw new InvalidOperationException("Payment Already Not Approved");

    public void Delete(AppointmentPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }

    public void Update(AppointmentPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }

    public void Add(AppointmentPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }
}