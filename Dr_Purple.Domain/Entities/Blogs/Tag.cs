using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Blogs;
public partial class Tag : AuditableEntity, IEntity
{
    public int Id { get; private set; }
}