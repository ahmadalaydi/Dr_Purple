using Dr_Purple.Domain.Entities.Works;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class WorkHoursExceptionConfig : IEntityTypeConfiguration<WorkHoursException>
{
    public void Configure(EntityTypeBuilder<WorkHoursException> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.Property(_ => _.StartDate).IsRequired();

        builder.Property(_ => _.EndDate).IsRequired();
    }
}