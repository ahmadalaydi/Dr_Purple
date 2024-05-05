using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class SaleSubDepartmentRepository : BaseRepository<SaleSubDepartment>, ISaleSubDepartmentRepository
{
    public SaleSubDepartmentRepository(AppDbContext dbContext) : base(dbContext) { }
}
