using Dr_Purple.Domain.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class MaterialSellPriceConfig : IEntityTypeConfiguration<MaterialSellPrice>
{
    public void Configure(EntityTypeBuilder<MaterialSellPrice> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Date).IsRequired();
        builder.Property(_ => _.Price).IsRequired();

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.MaterialSellPrices)
                .HasForeignKey(_ => _.MaterialId);
    }
}