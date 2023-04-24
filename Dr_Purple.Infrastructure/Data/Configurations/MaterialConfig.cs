using Dr_Purple.Domain.Entities.Materials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class MaterialConfig : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.UnitId).IsRequired();
        builder.Property(_ => _.IsForSale).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.HasOne(_ => _.Unit)
                .WithMany(_ => _.Materials)
                .HasForeignKey(_ => _.UnitId);

        builder.HasMany(_ => _.MaterialCostPrices)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.MaterialSellPrices)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.OrderItems)
                .WithOne(_ => _.Material);

        builder.HasMany(_ => _.SubDepartmentMaterials)
                .WithOne(_ => _.Material);
        
       builder.HasMany(_ => _.WareHouseMaterials)
                .WithOne(_ => _.Material);
    }
}