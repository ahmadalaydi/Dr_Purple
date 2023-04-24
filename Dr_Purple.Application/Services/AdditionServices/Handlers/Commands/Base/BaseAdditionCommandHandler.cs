using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.AdditionServices.Handlers.Commands.Base;
public class BaseAdditionCommandHandler : BaseHandler
{
    protected internal IAdditionRepository? Repository;
    public BaseAdditionCommandHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.AdditionRepository;
    }
}

