using Dr_Purple.Domain.Entities.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class ServiceConfig : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.HasIndex(_ => _.Name).IsUnique();

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.SubDepartmentId).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.Property(_ => _.Description).IsRequired().HasMaxLength(256);

        builder.HasOne(_ => _.SubDepartment)
                .WithMany(_ => _.Services)
                .HasForeignKey(_ => _.SubDepartmentId);

        builder.HasMany(_ => _.ContractServices)
                .WithOne(_ => _.Service);

        builder.HasMany(_ => _.ServiceTimes)
                .WithOne(_ => _.Service);
    }
}