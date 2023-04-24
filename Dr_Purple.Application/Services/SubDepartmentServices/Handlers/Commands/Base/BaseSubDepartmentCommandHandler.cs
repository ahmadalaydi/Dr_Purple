using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Handlers.Commands.Base;
public class BaseSubDepartmentCommandHandler : BaseHandler
{
    protected internal ISubDepartmentRepository? Repository;
    public BaseSubDepartmentCommandHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.SubDepartmentRepository;
    }
}

