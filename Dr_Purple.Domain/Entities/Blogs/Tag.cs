using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Blogs;
public partial class Tag : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public string Name { get; private set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<BlogTag> BlogTags { get; private set; } = new HashSet<BlogTag>();

    public Tag(string name)
      => Name = name;

    public static Tag Create(string name)
    => new(name);

    public void Update(string name)
     => Name = name;
}