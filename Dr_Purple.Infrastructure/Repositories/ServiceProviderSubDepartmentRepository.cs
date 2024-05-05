using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;

namespace Dr_Purple.Infrastructure.Repositories;
public class ServiceProviderSubDepartmentRepository : BaseRepository<ServiceProviderSubDepartment>, IServiceProviderSubDepartmentRepository
{
    public ServiceProviderSubDepartmentRepository(AppDbContext dbContext) : base(dbContext) { }
}
