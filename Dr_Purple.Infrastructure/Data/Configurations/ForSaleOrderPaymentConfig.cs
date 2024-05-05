using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Payments.State;
using Dr_Purple.Domain.Entities.Payments.Strategy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ForSaleOrderPaymentConfig : IEntityTypeConfiguration<ForSaleOrderPayment>
{
    public void Configure(EntityTypeBuilder<ForSaleOrderPayment> builder)
    {
        builder.ToTable("ForSaleOrderPayments");

        builder.Property(_ => _.State)
            .HasConversion(_ => _.GetType().Name, _ => GetState(_));

        builder.Property(_ => _.Strategy)
            .HasConversion(_ => _.GetType().Name,
                           _ => new ForSaleOrderPaymentStrategy());

        builder.HasOne(_ => _.SubDepartment)
       .WithMany(_ => _.OrderPayments)
       .HasForeignKey(_ => _.SubDepartmentId);

    }
    private static IPaymentState<ForSaleOrderPayment> GetState(string state)
    {
        return state switch
        {
            nameof(ApprovedForSaleOrderPaymentState) => new ApprovedForSaleOrderPaymentState(),
            nameof(NotApprovedForSaleOrderPaymentState) => new NotApprovedForSaleOrderPaymentState(),
            _ => throw new NotImplementedException(),
        };
    }
}