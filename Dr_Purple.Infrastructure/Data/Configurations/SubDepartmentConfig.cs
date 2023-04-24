using Dr_Purple.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class SubDepartmentConfig : IEntityTypeConfiguration<SubDepartment>
{
    public void Configure(EntityTypeBuilder<SubDepartment> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.Property(_ => _.DepartmentId).IsRequired();

        builder.HasOne(_ => _.Department)
                .WithMany(_ => _.SubDepartments)
                .HasForeignKey(_ => _.DepartmentId);

        builder.HasMany(_ => _.Contracts)
                .WithOne(_ => _.SubDepartment);

        builder.HasMany(_ => _.SubDepartmentMaterials)
                .WithOne(_ => _.SubDepartment);

        builder.HasMany(_ => _.Orders)
                .WithOne(_ => _.SubDepartment);

        builder.HasMany(_ => _.Payments)
                .WithOne(_ => _.SubDepartment);

        builder.HasMany(_ => _.Services)
                .WithOne(_ => _.SubDepartment);
    }
}