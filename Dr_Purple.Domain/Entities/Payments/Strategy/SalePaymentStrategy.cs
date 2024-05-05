namespace Dr_Purple.Domain.Entities.Payments.Strategy;
public class SalePaymentStrategy : IPaymentStrategy<SalePayment>
{
    public void CalculateAmount(SalePayment payment)
    {
        payment.SetAmount(payment!.Items.Sum(_ => _.Total));
    }
}