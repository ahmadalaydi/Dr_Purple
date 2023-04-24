using Dr_Purple.Domain.Entities.WareHouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class WareHouseMaterialConfig : IEntityTypeConfiguration<WareHouseMaterial>
{
    public void Configure(EntityTypeBuilder<WareHouseMaterial> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.WareHouseId).IsRequired();
        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Quantity).IsRequired();

        builder.HasOne(_ => _.WareHouse)
                .WithMany(_ => _.WareHouseMaterials)
                .HasForeignKey(_ => _.WareHouseId);

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.WareHouseMaterials)
                .HasForeignKey(_ => _.MaterialId);
    }
}