using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Materials.Interfaces;

namespace Dr_Purple.Domain.Entities.Materials.Base;
public abstract class Material : AuditableEntity, IMaterial
{
    public long Id { get; private set; }
    public string Name { get; private set; }
    public string Unit { get; private set; }
    public float CostPrice { get; private set; }

    protected internal Material(string name, string unit, float costPrice)
    {
        Name = name;
        Unit = unit;
        CostPrice = costPrice;
    }

    public void Update(string name, string unit, float costPrice)
    {
        Name = name;
        Unit = unit;
        CostPrice = costPrice;
    }
}