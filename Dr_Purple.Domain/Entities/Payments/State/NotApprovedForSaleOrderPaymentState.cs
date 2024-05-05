using Dr_Purple.Domain.Entities.Departments;

namespace Dr_Purple.Domain.Entities.Payments.State;
public class NotApprovedForSaleOrderPaymentState : IPaymentState<ForSaleOrderPayment>
{
    public void Approve(ForSaleOrderPayment payment)
    {
        foreach (var item in payment.Items!)
        {
            var material = payment!.SubDepartment!.Materials!
                .FirstOrDefault(_ => _.MaterialId.Equals(item.MaterialId));

            if (material is not null)
                material!.AddQuantity(item.Quantity);
            else
                payment.SubDepartment!.Materials.Add(
                    SaleSubDepartmentMaterial.Create(payment.SubDepartmentId,
                        item.MaterialId, item.Quantity));
        }
        payment.SetState(new ApprovedForSaleOrderPaymentState());
    }

    public void DeApprove(ForSaleOrderPayment payment)
    => throw new InvalidOperationException("Payment Already Not Approved");

    public void Delete(ForSaleOrderPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }

    public void Update(ForSaleOrderPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }

    public void Add(ForSaleOrderPayment payment)
    {
        payment.Strategy.CalculateAmount(payment);
    }
}