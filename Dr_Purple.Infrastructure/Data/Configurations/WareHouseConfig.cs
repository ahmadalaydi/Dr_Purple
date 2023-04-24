using Dr_Purple.Domain.Entities.WareHouses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class WareHouseConfig : IEntityTypeConfiguration<WareHouse>
{
    public void Configure(EntityTypeBuilder<WareHouse> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(_ => _.WareHouseMaterials)
                .WithOne(_ => _.WareHouse);

        builder.HasMany(_ => _.Orders)
                .WithOne(_ => _.WareHouse);
    }
}