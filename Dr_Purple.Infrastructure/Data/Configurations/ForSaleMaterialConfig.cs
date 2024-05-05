using Dr_Purple.Domain.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ForSaleMaterialConfig : IEntityTypeConfiguration<ForSaleMaterial>
{
    public void Configure(EntityTypeBuilder<ForSaleMaterial> builder)
    {
        builder.Property(_ => _.CostPrice).IsRequired();
        builder.Property(_ => _.SalePrice).IsRequired();

        builder.HasMany(_ => _.SellsPerMaterial)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.SubDepartmentMaterials)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.Items)
                .WithOne(_ => _.Material);
    }
}