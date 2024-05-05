using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class LeaveConfig : IEntityTypeConfiguration<Leave>
{
    public void Configure(EntityTypeBuilder<Leave> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.StartDate).IsRequired();
        builder.Property(_ => _.EndDate).IsRequired();

        builder.HasOne(_ => _.Contract)
                .WithMany(_ => _.Leaves)
                .HasForeignKey(_ => _.ContractId);

        builder.Property(_ => _.State)
                .HasConversion(_ => _.GetType().Name, _ => GetLeaveState(_));
    }

    private static ILeaveState GetLeaveState(string state)
        => state switch
        {
            nameof(NotApprovedLeaveState) => new NotApprovedLeaveState(),
            nameof(ApprovedLeaveState) => new ApprovedLeaveState(),
            _ => throw new NotImplementedException(),
        };
}