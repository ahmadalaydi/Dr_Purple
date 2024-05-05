using Dr_Purple.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ServiceProviderSubDepartmentConfig : IEntityTypeConfiguration<ServiceProviderSubDepartment>
{
    public void Configure(EntityTypeBuilder<ServiceProviderSubDepartment> builder)
    {
        builder.HasMany(_ => _.Materials)
                .WithOne(_ => _.SubDepartment)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.AppointmentPayments)
                .WithOne(_ => _.SubDepartment)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.Services)
                .WithOne(_ => _.SubDepartment)
                .HasForeignKey(_ => _.SubDepartmentId);
    }
}