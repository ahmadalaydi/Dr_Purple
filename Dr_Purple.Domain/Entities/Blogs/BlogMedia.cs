using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Blogs;
public partial class BlogMedia : IEntity
{
    public int BlogId { get; private set; }
}