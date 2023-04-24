using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class PaymentConfig : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.SubDepartmentId).IsRequired();
        builder.Property(_ => _.PaymentType).IsRequired().HasConversion<string>();
        builder.Property(_ => _.Status).IsRequired().HasConversion<string>();
        builder.Property(_ => _.Date).IsRequired();
        builder.Property(_ => _.Amount).IsRequired();

        builder.HasOne(_ => _.AppointmentPayment)
               .WithOne(_ => _.Payment)
               .HasForeignKey<AppointmentPayment>(_ => _.PaymentId);

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.Payments)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.PaymentMaterials)
                .WithOne(_ => _.Payment);

        builder.HasMany(_ => _.PaymentOffers)
                .WithOne(_ => _.Payment);
    }
}