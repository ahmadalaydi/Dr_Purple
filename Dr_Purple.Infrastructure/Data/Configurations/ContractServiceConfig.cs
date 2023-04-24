using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class ContractServiceConfig : IEntityTypeConfiguration<ContractService>
{
    public void Configure(EntityTypeBuilder<ContractService> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.HasOne(_ => _.Contract)
                .WithMany(_ => _.ContractServices)
                .HasForeignKey(_ => _.ContractId);

        builder.HasOne(_ => _.Service)
                .WithMany(_ => _.ContractServices)
                .HasForeignKey(_ => _.ServiceId);

        builder.HasMany(_ => _.ContractTimes)
                .WithOne(_ => _.ContractService);
    }
}