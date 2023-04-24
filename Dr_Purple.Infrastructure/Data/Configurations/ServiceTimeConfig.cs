using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ServiceTimeConfig : IEntityTypeConfiguration<ServiceTime>
{
    public void Configure(EntityTypeBuilder<ServiceTime> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.ServiceId).IsRequired();
        builder.Property(_ => _.StartTime).IsRequired()
               .HasConversion(v => v.ToTimeSpan(),
                              v => TimeOnly.FromTimeSpan(v));

        builder.Property(_ => _.EndTime).IsRequired()
               .HasConversion(v => v.ToTimeSpan(),
                              v => TimeOnly.FromTimeSpan(v));


        builder.HasOne(_ => _.Service)
                .WithMany(_ => _.ServiceTimes)
                .HasForeignKey(_ => _.ServiceId);

        builder.HasOne(_ => _.AppointmentServiceTime)
                .WithOne(_ => _.ServiceTime)
                .HasForeignKey<AppointmentServiceTime>(_ => _.ServiceTimeId);
    }
}