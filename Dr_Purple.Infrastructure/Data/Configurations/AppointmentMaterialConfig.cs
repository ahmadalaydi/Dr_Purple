using Dr_Purple.Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AppointmentMaterialConfig : IEntityTypeConfiguration<AppointmentMaterial>
{
    public void Configure(EntityTypeBuilder<AppointmentMaterial> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.AppointmentId).IsRequired();
        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Quantity).IsRequired();

        builder.HasOne(_ => _.Appointment)
                .WithMany(_ => _.AppointmentMaterials)
                .HasForeignKey(_ => _.AppointmentId);

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.AppointmentMaterials)
                .HasForeignKey(_ => _.MaterialId);
    }
}