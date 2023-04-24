using Dr_Purple.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class OrderItemConfig : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Quantity).IsRequired();
        builder.Property(_ => _.OrderId).IsRequired();

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.OrderItems)
                .HasForeignKey(_ => _.MaterialId);

        builder.HasOne(_ => _.Order)
                .WithMany(_ => _.OrderItems)
                .HasForeignKey(_ => _.OrderId);
    }
}