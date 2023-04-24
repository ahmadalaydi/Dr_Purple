using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.UnitServices.Handlers.Commands.Base;
public class BaseUnitCommandHandler : BaseHandler
{
    protected internal IUnitRepository? Repository;
    public BaseUnitCommandHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.UserRepository;
    }
}

