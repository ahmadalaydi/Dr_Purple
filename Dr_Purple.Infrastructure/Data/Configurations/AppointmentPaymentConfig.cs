using Dr_Purple.Domain.Entities.Appointments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AppointmentPaymentConfig : IEntityTypeConfiguration<AppointmentPayment>
{
    public void Configure(EntityTypeBuilder<AppointmentPayment> builder)
    {
        builder.HasKey(_ => new { _.PaymentId, _.AppointmentId });


    }
}