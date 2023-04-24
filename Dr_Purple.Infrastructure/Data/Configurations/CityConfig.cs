using Dr_Purple.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class CityConfig : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.HasMany(_ => _.Regions)
                .WithOne(_ => _.City);

        builder.HasMany(_ => _.Addresss)
                .WithOne(_ => _.City);
    }
}