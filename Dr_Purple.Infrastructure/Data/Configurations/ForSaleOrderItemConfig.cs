using Dr_Purple.Domain.Entities.Payments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class ForSaleOrderItemConfig : IEntityTypeConfiguration<ForSaleOrderItem>
{
    public void Configure(EntityTypeBuilder<ForSaleOrderItem> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.CostPrice).IsRequired();
        builder.Property(_ => _.Quantity).IsRequired();
        builder.Property(_ => _.Total).IsRequired();

        builder.HasOne(_ => _.Payment)
               .WithMany(_ => _.Items)
               .HasForeignKey(_ => _.PaymentId);

        builder.HasOne(_ => _.Material)
               .WithMany(_ => _.Items)
               .HasForeignKey(_ => _.MaterialId);
    }
}
