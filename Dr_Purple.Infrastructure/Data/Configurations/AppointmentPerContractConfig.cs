using Dr_Purple.Domain.Entities.Reports;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class AppointmentPerContractConfig : IEntityTypeConfiguration<AppointmentPerContract>
{
    public void Configure(EntityTypeBuilder<AppointmentPerContract> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Count).IsRequired();
        builder.Property(_ => _.Date).IsRequired()
                .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.Property(_ => _.ContractId).IsRequired();

        builder.HasOne(_ => _.Contract)
               .WithMany(_ => _.AppointmentsPerContract)
               .HasForeignKey(_ => _.ContractId);
    }
}
