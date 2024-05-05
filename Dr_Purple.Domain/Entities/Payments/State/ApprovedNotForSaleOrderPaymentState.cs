namespace Dr_Purple.Domain.Entities.Payments.State;
public class ApprovedNotForSaleOrderPaymentState : IPaymentState<NotForSaleOrderPayment>
{
    public void Approve(NotForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void DeApprove(NotForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Delete(NotForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Update(NotForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Add(NotForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");
}