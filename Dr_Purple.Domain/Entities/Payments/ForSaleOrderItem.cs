using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Payments;
[NotAuditable]
public partial class ForSaleOrderItem : IEntity
{
    public long Id { get; private set; }
    public Guid PaymentId { get; private set; }
    public long MaterialId { get; private set; }
    public float CostPrice { get; private set; }
    public float Quantity { get; private set; }
    public float Total { get; private set; }
    [JsonIgnore]
    public virtual ForSaleOrderPayment? Payment { get; private set; }
    [JsonIgnore]
    public virtual ForSaleMaterial? Material { get; private set; }
    protected internal ForSaleOrderItem(Guid paymentId, long materialId, float costPrice, float quantity)
    {
        PaymentId = paymentId;
        MaterialId = materialId;
        CostPrice = costPrice;
        Quantity = quantity;
        Total = costPrice * quantity;
    }
    public static ForSaleOrderItem Create(Guid paymentId, long materialId, float costPrice, float quantity)
    => new(paymentId, materialId, costPrice, quantity);

    public void Update(float costPrice, float quantity)
    {
        CostPrice = costPrice;
        Quantity = quantity;
        Total = costPrice * quantity;
    }
}