using Dr_Purple.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class RegionConfig : IEntityTypeConfiguration<Region>
{
    public void Configure(EntityTypeBuilder<Region> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.CityId).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.HasOne(_ => _.City)
                .WithMany(_ => _.Regions)
                .HasForeignKey(_ => _.CityId);

        builder.HasMany(_ => _.Addresss)
                .WithOne(_ => _.Region);
    }
}