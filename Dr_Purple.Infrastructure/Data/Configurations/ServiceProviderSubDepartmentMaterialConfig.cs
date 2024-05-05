using Dr_Purple.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ServiceProviderSubDepartmentMaterialConfig : IEntityTypeConfiguration<ServiceProviderSubDepartmentMaterial>
{
    public void Configure(EntityTypeBuilder<ServiceProviderSubDepartmentMaterial> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Quantity).IsRequired();

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.Materials)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasOne(_ => _.Material)
                .WithMany(_ => _.SubDepartmentMaterials)
                .HasForeignKey(_ => _.SubDepartmentId);
    }
}