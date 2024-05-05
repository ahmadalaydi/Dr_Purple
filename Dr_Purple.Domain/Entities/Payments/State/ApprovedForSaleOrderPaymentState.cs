namespace Dr_Purple.Domain.Entities.Payments.State;
public class ApprovedForSaleOrderPaymentState : IPaymentState<ForSaleOrderPayment>
{
    public void Approve(ForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void DeApprove(ForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Delete(ForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Update(ForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Add(ForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Approved");
}