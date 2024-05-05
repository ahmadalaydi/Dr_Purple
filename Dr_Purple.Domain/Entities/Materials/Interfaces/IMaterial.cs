using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Materials.Interfaces;
public interface IMaterial : IEntity
{
    static ForSaleMaterial Create(string name, string unit, float costPrice, float salePrice)
        => ForSaleMaterial.Create(name, unit, costPrice, salePrice);

    static NotForSaleMaterial Create(string name, string unit, float costPrice)
        => NotForSaleMaterial.Create(name, unit, costPrice);

    void Update(string name, string unit, float costPrice)
        => Update(name, unit, costPrice);

    void Update(string name, string unit, float costPrice, float salePrice)
        => Update(name, unit, costPrice, salePrice);
}