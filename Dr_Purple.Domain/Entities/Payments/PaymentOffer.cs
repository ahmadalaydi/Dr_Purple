using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Offers;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments;
public partial class PaymentOffer : AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public long? PaymentId { get; private set; }
    public int? OfferId { get; private set; }
    public Payment? Payment { get; private set; }
    public Offer? Offer { get; private set; }
}