using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Offers;
public partial class OfferDate : IEntity
{
    public int? Id { get; private set; }
    public int? OfferId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime? EndDate { get; private set; }
    public Offer? Offer { get; private set; }
}