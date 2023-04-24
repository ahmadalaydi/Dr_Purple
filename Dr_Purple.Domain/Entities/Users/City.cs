using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Users;
public partial class City : IEntity
{
    public long? Id { get; private set; }
    public string? Name { get; private set; }
    public virtual ICollection<Region>? Regions { get; private set; }
    public virtual ICollection<Address>? Addresss { get; private set; }
}