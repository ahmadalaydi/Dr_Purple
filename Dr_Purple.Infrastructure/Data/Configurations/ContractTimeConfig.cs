using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class ContractTimeConfig : IEntityTypeConfiguration<ContractTime>
{
    public void Configure(EntityTypeBuilder<ContractTime> builder)
    {
        builder.HasKey(_=>_.Id);

        builder.Property(_ => _.ContractServiceId).IsRequired();
        builder.Property(_ => _.Day).IsRequired();
        builder.Property(_ => _.StartTime).IsRequired()
               .HasConversion(v => v.ToTimeSpan(),
                              v => TimeOnly.FromTimeSpan(v));

        builder.Property(_ => _.EndTime).IsRequired()
               .HasConversion(v => v.ToTimeSpan(),
                              v => TimeOnly.FromTimeSpan(v));

        builder.HasOne(_ => _.ContractService)
                .WithMany(_ => _.ContractTimes)
                .HasForeignKey(_ => _.ContractServiceId);
    }
}