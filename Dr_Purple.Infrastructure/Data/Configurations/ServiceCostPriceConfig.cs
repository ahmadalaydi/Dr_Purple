using Dr_Purple.Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ServiceCostPriceConfig : IEntityTypeConfiguration<ServiceCostPrice>
{
    public void Configure(EntityTypeBuilder<ServiceCostPrice> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.ServiceId).IsRequired();
        builder.Property(_ => _.Date).IsRequired();
        builder.Property(_ => _.Cost).IsRequired();

        builder.HasOne(_ => _.Service)
                .WithMany(_ => _.ServiceCostPrices)
                .HasForeignKey(_ => _.ServiceId);
    }
}