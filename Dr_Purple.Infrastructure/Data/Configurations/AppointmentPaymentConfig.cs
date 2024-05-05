using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AppointmentPaymentConfig : IEntityTypeConfiguration<AppointmentPayment>
{
    public void Configure(EntityTypeBuilder<AppointmentPayment> builder)
    {
        builder.HasOne(_ => _.Appointment)
               .WithOne(_ => _.AppointmentPayment);

        builder.HasOne(_ => _.SubDepartment)
               .WithMany(_ => _.AppointmentPayments);

        builder.Property(_ => _.State)
               .HasConversion(_ => _.GetType().Name, _ => GetState(_));

        builder.Property(_ => _.Strategy)
               .HasConversion(_ => _.GetType().Name,
                           _ => new AppointmentPaymentStrategy());
    }
    private static IPaymentState<AppointmentPayment> GetState(string state)
    {
        return state switch
        {
            nameof(NotApprovedAppointmentPaymentState) => new NotApprovedAppointmentPaymentState(),
            nameof(ApprovedAppointmentPaymentState) => new ApprovedAppointmentPaymentState(),
            _ => throw new NotImplementedException(),
        };
    }
}