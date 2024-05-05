using Dr_Purple.Domain.Entities.Blogs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Dr_Purple.Infrastructure.Data.Configurations;
internal sealed class BlogConfig : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(_ => _.Title).IsRequired().HasMaxLength(100);
        builder.Property(_ => _.Content).IsRequired();

        builder.HasMany(_ => _.BlogTags)
        .WithOne(_ => _.Blog)
        .HasForeignKey(_ => _.BlogId)
        .OnDelete(DeleteBehavior.NoAction);
    }
}
