using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class ContractConfig : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.SubDepartmentId).IsRequired();
        builder.Property(_ => _.UserId).IsRequired();
        builder.Property(_ => _.IsActive).IsRequired();
        builder.Property(_ => _.Salary).IsRequired();
        builder.Property(_ => _.StartDate).IsRequired()
               .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.Property(_ => _.EndtDate).IsRequired()
               .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.HasOne(_ => _.User)
                .WithMany(_ => _.Contracts)
                .HasForeignKey(_ => _.UserId);

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.Contracts)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.ContractServices)
                .WithOne(_ => _.Contract);

        builder.HasMany(_ => _.Additions)
                .WithOne(_ => _.Contract);

        builder.HasMany(_ => _.Leaves)
                .WithOne(_ => _.Contract);

        builder.HasMany(_ => _.Attends)
                .WithOne(_ => _.Contract);

        builder.HasMany(_ => _.LeaveBalances)
                .WithOne(_ => _.Contract);
    }
}