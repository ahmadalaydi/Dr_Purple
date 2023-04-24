using Dr_Purple.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.PasswordHash).IsRequired();
        builder.Property(_ => _.PasswordSalt).IsRequired();
        builder.Property(_ => _.RefreshToken).IsRequired();
        builder.Property(_ => _.RefreshTokenExpiryTime).IsRequired();
        builder.Property(_ => _.Role).IsRequired().HasConversion<string>();
        builder.Property(_ => _.Gender).IsRequired().HasConversion<string>();
        builder.Property(_ => _.UserName).IsRequired().HasMaxLength(100);
        builder.Property(_ => _.FirstName).IsRequired().HasMaxLength(100);
        builder.Property(_ => _.LastName).IsRequired().HasMaxLength(100);
        builder.Property(_ => _.ContactNumber).IsRequired().HasMaxLength(20);
        //builder.Property(_ => _.Address).HasMaxLength(150);

        //builder.HasOne(_ => _.Address)
        //        .WithMany(_ => _.Users)
        //        .HasForeignKey(_ => _.AddressId);

        builder.HasMany(_ => _.Appointments)
                .WithOne(_ => _.User);

        builder.HasMany(_ => _.Contracts)
                .WithOne(_ => _.User);
    }
}