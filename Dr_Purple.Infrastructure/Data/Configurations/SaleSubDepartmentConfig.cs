using Dr_Purple.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class SaleSubDepartmentConfig : IEntityTypeConfiguration<SaleSubDepartment>
{
    public void Configure(EntityTypeBuilder<SaleSubDepartment> builder)
    {
        builder.HasMany(_ => _.Materials)
                .WithOne(_ => _.SubDepartment)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.OrderPayments)
                .WithOne(_ => _.SubDepartment)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.SalePayments)
                .WithOne(_ => _.SubDepartment)
                .HasForeignKey(_ => _.SubDepartmentId);
    }
}