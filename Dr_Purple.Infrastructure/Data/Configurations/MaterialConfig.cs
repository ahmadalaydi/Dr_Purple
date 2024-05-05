using Dr_Purple.Domain.Entities.Materials.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class MaterialConfig : IEntityTypeConfiguration<Material>
{
    public void Configure(EntityTypeBuilder<Material> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.UseTpcMappingStrategy();

        builder.HasIndex(_ => _.Name).IsUnique();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
    }
}