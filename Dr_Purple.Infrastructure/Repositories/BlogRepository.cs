using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class BlogRepository : BaseRepository<Blog>, IBlogRepository
{
    public BlogRepository(AppDbContext dbContext) : base(dbContext) { }
}
