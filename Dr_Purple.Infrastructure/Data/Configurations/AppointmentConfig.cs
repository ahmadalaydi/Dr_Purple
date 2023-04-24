using Dr_Purple.Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(_=>_.Id);

        builder.HasOne(_ => _.User)
               .WithMany(_ => _.Appointments)
               .HasForeignKey(_ => _.UserId);

        builder.HasMany(_ => _.AppointmentMaterials)
               .WithOne(_ => _.Appointment)
               .HasForeignKey(_ => _.AppointmentId);

        builder.HasOne(_ => _.AppointmentPayment)
               .WithOne(_ => _.Appointment)
               .HasForeignKey<AppointmentPayment>(_ => _.AppointmentId);

        builder.HasOne(_ => _.AppointmentServiceTime)
               .WithOne(_ => _.Appointment)
               .HasForeignKey<AppointmentServiceTime> (_=>_.AppointmentId);
    }
}