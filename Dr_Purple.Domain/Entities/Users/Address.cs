using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Users;
public partial class Address : IEntity
{
    public long? Id { get; private set; }
    public long? CityId { get; private set; }
    public long? RegionId { get; private set; }
    public string? Street { get; private set; }
    public City? City { get; private set; }
    public Region? Region { get; private set; }
    public virtual ICollection<User>? Users { get; private set; }
}