using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class AdministrativeSubDepartmentRepository : BaseRepository<AdministrativeSubDepartment>, IAdministrativeSubDepartmentRepository
{
    public AdministrativeSubDepartmentRepository(AppDbContext dbContext) : base(dbContext) { }
}
