using Dr_Purple.Domain.Entities.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class JobTitleConfig : IEntityTypeConfiguration<JobTitle>
{
    public void Configure(EntityTypeBuilder<JobTitle> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.HasIndex(_ => _.Name).IsUnique();
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
        builder.HasMany(_ => _.Contracts)
               .WithOne(_ => _.JobTitle)
               .HasForeignKey(_ => _.JobTitleId);
    }
}