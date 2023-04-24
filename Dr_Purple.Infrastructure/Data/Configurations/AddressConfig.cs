using Dr_Purple.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class AddressConfig : IEntityTypeConfiguration<Address>
{
    public void Configure(EntityTypeBuilder<Address> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Street).IsRequired().HasMaxLength(100);

        builder.HasOne(_ => _.City)
               .WithMany(_ => _.Addresss)
               .HasForeignKey(_ => _.CityId);

        builder.HasOne(_ => _.Region)
               .WithMany(_ => _.Addresss)
               .HasForeignKey(_ => _.RegionId);
    }
}