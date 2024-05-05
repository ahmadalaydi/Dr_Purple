using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AppointmentConfig : IEntityTypeConfiguration<Appointment>
{
    public void Configure(EntityTypeBuilder<Appointment> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.RowVersion)
            .IsConcurrencyToken()
            .ValueGeneratedOnAddOrUpdate();

        builder.HasOne(_ => _.User)
               .WithMany(_ => _.Appointments)
               .HasForeignKey(_ => _.UserId);

        builder.HasMany(_ => _.AppointmentMaterials)
               .WithOne(_ => _.Appointment)
               .HasForeignKey(_ => _.AppointmentId);

        builder.HasOne(_ => _.AppointmentPayment)
               .WithOne(_ => _.Appointment)
               .HasForeignKey<AppointmentPayment>(_ => _.AppointmentId)
               .OnDelete(DeleteBehavior.NoAction);
    }
}