using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class TagRepository : BaseRepository<Tag>, ITagRepository
{
    public TagRepository(AppDbContext dbContext) : base(dbContext) { }
}
