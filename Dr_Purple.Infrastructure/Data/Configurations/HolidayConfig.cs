using Dr_Purple.Domain.Entities.Works;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class HolidayConfig : IEntityTypeConfiguration<Holiday>
{
    public void Configure(EntityTypeBuilder<Holiday> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.Property(_ => _.Date).IsRequired()
       .HasConversion(v => v.ToDateTime(default),
                      v => DateOnly.FromDateTime(v));
    }
}