using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class SalePaymentConfig : IEntityTypeConfiguration<SalePayment>
{
    public void Configure(EntityTypeBuilder<SalePayment> builder)
    {
        builder.ToTable("SalePayments");

        builder.Property(_ => _.State)
            .HasConversion(_ => _.GetType().Name, _ => GetState(_));

        builder.Property(_ => _.Strategy)
            .HasConversion(_ => _.GetType().Name,
                           _ => new SalePaymentStrategy());

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.SalePayments)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.Items)
                .WithOne(_ => _.Payment)
                .HasForeignKey(_ => _.PaymentId);
    }
    private static IPaymentState<SalePayment> GetState(string state)
    {
        return state switch
        {
            nameof(NotApprovedSalePaymentState) => new NotApprovedSalePaymentState(),
            nameof(ApprovedSalePaymentState) => new ApprovedSalePaymentState(),
            _ => throw new NotImplementedException(),
        };
    }

    //private static IPaymentStrategy<SalePayment> GetStrategy(string state)
    //{
    //    return state switch
    //    {
    //        nameof(AppointmentPaymentStrategy) => new AppointmentPaymentStrategy(),
    //        nameof(SalePaymentStrategy) => new SalePaymentStrategy(),
    //        nameof(WareHousePaymentStrategy) => new WareHousePaymentStrategy(),
    //    };
    //}
}