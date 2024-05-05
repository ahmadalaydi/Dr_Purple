using Dr_Purple.Domain.Entities.Departments;

namespace Dr_Purple.Domain.Entities.Payments.State;
public class NotApprovedNotForSaleOrderPaymentState : IPaymentState<NotForSaleOrderPayment>
{
    public void Approve(NotForSaleOrderPayment payment)
    {
        foreach (var item in payment.Items!)
        {
            var material = payment!.SubDepartment!.Materials!
                .FirstOrDefault(_ => _.MaterialId.Equals(item.MaterialId));

            if (material is not null)
                material!.AddQuantity(item.Quantity);
            else
                payment.SubDepartment!.Materials.Add(
                    ServiceProviderSubDepartmentMaterial.Create(payment.SubDepartmentId,
                        item.MaterialId, item.Quantity));
        }
        payment.SetState(new ApprovedNotForSaleOrderPaymentState());
    }

    public void DeApprove(NotForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Not Approved");

    public void Delete(NotForSaleOrderPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }

    public void Update(NotForSaleOrderPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }

    public void Add(NotForSaleOrderPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }
}