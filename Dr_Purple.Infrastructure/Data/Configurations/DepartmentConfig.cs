﻿using Dr_Purple.Domain.Entities.Departments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
internal sealed class DepartmentConfig : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.HasKey(_ => _.Id);

        builder.Property(_ => _.Id).IsRequired();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(_ => _.SubDepartments)
                .WithOne(_ => _.Department);
    }
}
