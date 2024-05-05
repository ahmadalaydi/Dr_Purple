using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Blogs;
public partial class Blog : AuditableEntity, IEntity
{
    public long Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Content { get; private set; } = string.Empty;
    public bool IsPublished { get; private set; }
    public string PicPath { get; private set; } = string.Empty;

    [JsonIgnore]
    public virtual ICollection<BlogTag> BlogTags { get; private set; } = new HashSet<BlogTag>();

    protected Blog(string title, string content, bool isPublished, string picPath)
    {
        Title = title;
        Content = content;
        IsPublished = isPublished;
        PicPath = picPath;
    }
    public static Blog Create(string title, string content, bool isPublished, string picPath)
        => new(title, content, isPublished, picPath);
    public void Update(string title, string content, bool isPublished, string picPath)
    {
        Title = title;
        Content = content;
        IsPublished = isPublished;
        PicPath = picPath;
    }
}