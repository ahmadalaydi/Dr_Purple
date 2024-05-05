namespace Dr_Purple.Domain.Entities.Payments.State;
public class ApprovedSalePaymentState : IPaymentState<SalePayment>
{
    public void Approve(SalePayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void DeApprove(SalePayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Delete(SalePayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Update(SalePayment payment)
    => throw new InvalidOperationException("Payment Already Approved");

    public void Add(SalePayment payment)
    => throw new InvalidOperationException("Payment Already Approved");
}