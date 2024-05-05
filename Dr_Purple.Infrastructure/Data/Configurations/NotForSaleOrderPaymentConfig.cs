using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class NotForSaleOrderPaymentConfig : IEntityTypeConfiguration<NotForSaleOrderPayment>
{
    public void Configure(EntityTypeBuilder<NotForSaleOrderPayment> builder)
    {
        builder.ToTable("NotForSaleOrderPayments");

        builder.Property(_ => _.State)
            .HasConversion(_ => _.GetType().Name, _ => GetState(_));

        builder.Property(_ => _.Strategy)
            .HasConversion(_ => _.GetType().Name,
                           _ => new NotForSaleOrderPaymentStrategy());

        builder.HasOne(_ => _.SubDepartment)
               .WithMany(_ => _.OrderPayments)
               .HasForeignKey(_ => _.SubDepartmentId);
    }
    private static IPaymentState<NotForSaleOrderPayment> GetState(string state)
    {
        return state switch
        {
            nameof(NotApprovedNotForSaleOrderPaymentState) => new NotApprovedNotForSaleOrderPaymentState(),
            nameof(ApprovedNotForSaleOrderPaymentState) => new ApprovedNotForSaleOrderPaymentState(),
            _ => throw new NotImplementedException(),
        };
    }
}