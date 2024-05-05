using Dr_Purple.Domain.Entities.Blogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class TagConfig : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);

        builder.HasMany(_ => _.BlogTags)
            .WithOne(_ => _.Tag)
            .HasForeignKey(_ => _.TagId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
