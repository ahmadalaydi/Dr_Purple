using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Offers;
public partial class Offer : AuditableEntity, IEntity
{
    public int? Id { get; private set; }
    public string? Name { get; private set; }
    public float? Discount { get; private set; }
    public bool? IsPercent { get; private set; }
    public bool? IsUnlimited { get; private set; }
    public virtual ICollection<OfferDate>? OfferDates { get; private set; }
    public virtual ICollection<PaymentOffer>? PaymentOffers { get; private set; }
}