using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AppointmentServiceTimeConfig : IEntityTypeConfiguration<AppointmentServiceTime>
{
    public void Configure(EntityTypeBuilder<AppointmentServiceTime> builder)
    {
        builder.HasKey(_ => new { _.ServiceTimeId, _.AppointmentId });
    }
}