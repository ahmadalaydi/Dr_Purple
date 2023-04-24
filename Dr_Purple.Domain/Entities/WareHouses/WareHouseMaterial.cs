using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.WareHouses;
public partial class WareHouseMaterial : IEntity
{
    public long? Id { get; private set; }
    public long? WareHouseId { get; private set; }
    public int? MaterialId { get; private set; }
    public float? Quantity { get; private set; }
    public WareHouse? WareHouse { get; private set; }
    public Material? Material { get; private set; }
}
