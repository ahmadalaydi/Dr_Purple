using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class SalePaymentItem : IEntity
{
    public long Id { get; private set; }
    public Guid PaymentId { get; private set; }
    public long MaterialId { get; private set; }
    public float SalePrice { get; private set; }
    public float Quantity { get; private set; }
    public float Total { get; private set; }
    public virtual SalePayment? Payment { get; private set; }
    public virtual ForSaleMaterial? Material { get; private set; }

    protected internal SalePaymentItem(Guid paymentId, long materialId, float salePrice, float quantity)
    {
        PaymentId = paymentId;
        MaterialId = materialId;
        SalePrice = salePrice;
        Quantity = quantity;
        Total = salePrice * quantity;
    }
    public static SalePaymentItem Create(Guid paymentId, long materialId, float salePrice, float quantity)
    => new(paymentId, materialId, salePrice, quantity);

    public void Update(float salePrice, float quantity)
    {
        Quantity = quantity;
        SalePrice = salePrice;
        Total = salePrice * quantity;
    }
}