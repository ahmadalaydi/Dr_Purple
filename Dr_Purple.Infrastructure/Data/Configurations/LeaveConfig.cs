using Dr_Purple.Domain.Entities.Leaves;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class LeaveConfig : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.LeaveType).IsRequired().HasConversion<string>();
        builder.Property(_ => _.StartDate).IsRequired();
        builder.Property(_ => _.EndtDate).IsRequired();

        builder.HasOne(_ => _.Contract)
                .WithMany(_ => _.Leaves)
                .HasForeignKey(_ => _.ContractId);
    }
}