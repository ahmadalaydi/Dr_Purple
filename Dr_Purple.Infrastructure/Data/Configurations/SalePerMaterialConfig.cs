using Dr_Purple.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class SalePerMaterialConfig : IEntityTypeConfiguration<SalePerMaterial>
{
    public void Configure(EntityTypeBuilder<SalePerMaterial> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Count).IsRequired();

        builder.Property(_ => _.Date).IsRequired()
                .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));
    }
}
