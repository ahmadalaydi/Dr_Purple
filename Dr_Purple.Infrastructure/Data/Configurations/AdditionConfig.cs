using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class AdditionConfig : IEntityTypeConfiguration<Addition>
{
    public void Configure(EntityTypeBuilder<Addition> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.HasOne(_ => _.Contract)
               .WithMany(_ => _.Additions)
               .HasForeignKey(_ => _.ContractId);
    }
}
