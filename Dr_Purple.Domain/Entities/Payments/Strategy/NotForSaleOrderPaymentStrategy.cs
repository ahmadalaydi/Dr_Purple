using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Entities.Payments.Base;

namespace Dr_Purple.Domain.Entities.Payments.Strategy;
public class NotForSaleOrderPaymentStrategy : IPaymentStrategy<NotForSaleOrderPayment>
{
    public void CalculateAmount(NotForSaleOrderPayment payment)
    {
        payment.SetAmount(payment!.Items!.Sum(_ => _.Total));
    }
}