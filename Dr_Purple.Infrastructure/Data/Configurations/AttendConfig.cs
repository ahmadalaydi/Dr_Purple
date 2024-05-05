using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class AttendConfig : IEntityTypeConfiguration<Attend>
{
    public void Configure(EntityTypeBuilder<Attend> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.HasOne(_ => _.Contract)
                .WithMany(_ => _.Attends)
                .HasForeignKey(_ => _.ContractId);
    }
}