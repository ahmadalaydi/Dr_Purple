using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class LeaveBalanceConfig : IEntityTypeConfiguration<LeaveBalance>
{
    public void Configure(EntityTypeBuilder<LeaveBalance> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.ContractId).IsRequired();
        builder.Property(_ => _.Balance).IsRequired();
        builder.Property(_ => _.StartDate).IsRequired()
               .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.Property(_ => _.EndDate).IsRequired()
               .HasConversion(v => v.ToDateTime(default),
                              v => DateOnly.FromDateTime(v));

        builder.HasOne(_ => _.Contract)
                .WithMany(_ => _.LeaveBalances)
                .HasForeignKey(_ => _.ContractId);
    }
}