using Dr_Purple.Domain.Entities.Departments.Base;

namespace Dr_Purple.Domain.Entities.Payments.Strategy;
public class ForSaleOrderPaymentStrategy : IPaymentStrategy<ForSaleOrderPayment>
{
    public void CalculateAmount(ForSaleOrderPayment payment)
    {
        
        payment.SetAmount(payment!.Items!.Sum(_ => _.Total));
    }
}