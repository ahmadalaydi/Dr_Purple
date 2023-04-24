using Dr_Purple.Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class OrderConfig : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.SubDepartmentId).IsRequired();
        builder.Property(_ => _.WareHouseId).IsRequired();
        builder.Property(_ => _.Status).IsRequired().HasConversion<string>();
        builder.Property(_ => _.Date).IsRequired();

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.Orders)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasOne(_ => _.WareHouse)
                .WithMany(_ => _.Orders)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.OrderItems)
                .WithOne(_ => _.Order);
    }
}