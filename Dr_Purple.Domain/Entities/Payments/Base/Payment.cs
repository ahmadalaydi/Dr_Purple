using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Payments.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments.Base;
public abstract class Payment : AuditableEntity, IPayment
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; } = DateTime.Now;
    public float Amount { get; private set; } = 0f;
    public byte[]? RowVersion { get; set; }
    protected Payment(Guid id) => Id = id;
    internal void SetAmount(float amount)
    => Amount = amount;
}