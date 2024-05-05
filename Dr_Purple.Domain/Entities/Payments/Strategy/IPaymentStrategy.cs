using Dr_Purple.Domain.Entities.Payments.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments.Strategy;
public interface IPaymentStrategy<T> where T : class, IPayment
{
    void CalculateAmount(T payment);
}