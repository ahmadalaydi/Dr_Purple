using Dr_Purple.Domain.Entities.Payments.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments.State;
public interface IPaymentState<T> where T : class, IPayment
{
    void Approve(T payment);
    void DeApprove(T payment);
    void Add(T payment);
    void Delete(T payment);
    void Update(T payment);
}