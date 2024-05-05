namespace Dr_Purple.Domain.Entities.Payments.Strategy;
public class AppointmentPaymentStrategy : IPaymentStrategy<AppointmentPayment>
{
    public void CalculateAmount(AppointmentPayment payment)
        => payment.SetAmount(payment.Appointment!.ServiceTime!.Service!.Price);
}