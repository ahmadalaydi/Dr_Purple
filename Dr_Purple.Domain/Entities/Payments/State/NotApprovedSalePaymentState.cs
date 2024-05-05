namespace Dr_Purple.Domain.Entities.Payments.State;
public class NotApprovedSalePaymentState : IPaymentState<SalePayment>
{
    public void Approve(SalePayment payment)
    {
        Parallel.ForEach(payment.Items, item =>
        {
            payment.SubDepartment!.Materials
            .FirstOrDefault(_ => _.MaterialId.Equals(item.MaterialId))!
            .MinQuantity(item.Quantity);
        });
        payment.SetState(new ApprovedSalePaymentState());
    }

    public void DeApprove(SalePayment payment)
    => throw new InvalidOperationException("Payment Already Not Approved");

    public void Delete(SalePayment payment)
    => payment.Strategy.CalculateAmount(payment);

    public void Update(SalePayment payment)
    => payment.Strategy.CalculateAmount(payment);

    public void Add(SalePayment payment)
    => payment.Strategy.CalculateAmount(payment);
}