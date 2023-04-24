using Dr_Purple.Domain.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class MaterialCostPriceConfig : IEntityTypeConfiguration<MaterialCostPrice>
{
    public void Configure(EntityTypeBuilder<MaterialCostPrice> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Date).IsRequired();
        builder.Property(_ => _.Price).IsRequired();

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.MaterialCostPrices)
                .HasForeignKey(_ => _.MaterialId);
    }
}