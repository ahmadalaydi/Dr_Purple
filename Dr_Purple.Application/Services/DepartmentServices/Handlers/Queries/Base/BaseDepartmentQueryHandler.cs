using Dr_Purple.Application.Services.Base;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.DepartmentServices.Handlers.Queries.Base;
public class BaseDepartmentQueryHandler : BaseHandler
{
    protected internal IDepartmentRepository? Repository;
    public BaseDepartmentQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.DepartmentRepository;
    }
}
