using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Blogs;
[NotAuditable]
public partial class BlogTag : IEntity
{
    public long BlogId { get; private set; }
    public long TagId { get; private set; }

    [JsonIgnore]
    public virtual Blog? Blog { get; private set; }

    [JsonIgnore]
    public virtual Tag? Tag { get; private set; }
    protected BlogTag(long blogId, long tagId)
    {
        BlogId = blogId;
        TagId = tagId;
    }
    public static BlogTag Create(long blogId, long tagId)
        => new(blogId, tagId);
    public void Update(long blogId, long tagId)
    {
        BlogId = blogId;
        TagId = tagId;
    }
}