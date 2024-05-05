using Dr_Purple.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class AppointmentPerServiceConfig : IEntityTypeConfiguration<AppointmentPerService>
{
    public void Configure(EntityTypeBuilder<AppointmentPerService> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.ServiceId).IsRequired();
        builder.Property(_ => _.Count).IsRequired();

        builder.Property(_ => _.Date).IsRequired()
                .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.HasOne(_ => _.Service)
               .WithMany(_ => _.AppointmentsPerService)
               .HasForeignKey(_ => _.ServiceId);
    }
}
