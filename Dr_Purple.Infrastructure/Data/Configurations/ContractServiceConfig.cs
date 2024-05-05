using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class ContractServiceConfig : IEntityTypeConfiguration<ContractService>
{
    public void Configure(EntityTypeBuilder<ContractService> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.StartTime).IsRequired();
        builder.Property(_ => _.EndTime).IsRequired();

        builder.HasOne(_ => _.Contract)
                .WithMany(_ => _.ContractServices)
                .HasForeignKey(_ => _.ContractId);

        builder.HasOne(_ => _.Service)
                .WithMany(_ => _.ContractServices)
                .HasForeignKey(_ => _.ServiceId)
                .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(_ => _.ServiceTimes)
                .WithOne(_ => _.ContractService)
                .HasForeignKey(_ => _.ContractServiceId)
                .OnDelete(DeleteBehavior.NoAction);
    }
}