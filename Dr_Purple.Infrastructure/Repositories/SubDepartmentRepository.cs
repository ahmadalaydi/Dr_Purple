using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class SubDepartmentRepository : BaseRepository<SubDepartment>, ISubDepartmentRepository
{
    public SubDepartmentRepository(AppDbContext? dbContext) : base(dbContext) { }
}
