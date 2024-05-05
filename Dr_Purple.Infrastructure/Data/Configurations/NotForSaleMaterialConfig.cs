using Dr_Purple.Domain.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class NotForSaleMaterialConfig : IEntityTypeConfiguration<NotForSaleMaterial>
{
    public void Configure(EntityTypeBuilder<NotForSaleMaterial> builder)
    {
        builder.Property(_ => _.CostPrice).IsRequired();

        builder.HasMany(_ => _.AppointmentMaterials)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.SubDepartmentMaterials)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.Items)
                .WithOne(_ => _.Material);
    }
}