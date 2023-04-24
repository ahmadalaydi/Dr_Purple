using Dr_Purple.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class SubDepartmentMaterialConfig : IEntityTypeConfiguration<SubDepartmentMaterial>
{
    public void Configure(EntityTypeBuilder<SubDepartmentMaterial> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.SubDepartmentId).IsRequired();
        builder.Property(_ => _.MaterialId).IsRequired();
        builder.Property(_ => _.Quantity).IsRequired();

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.SubDepartmentMaterials)
                .HasForeignKey(_ => _.MaterialId);

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.SubDepartmentMaterials)
                .HasForeignKey(_ => _.SubDepartmentId);
    }
}