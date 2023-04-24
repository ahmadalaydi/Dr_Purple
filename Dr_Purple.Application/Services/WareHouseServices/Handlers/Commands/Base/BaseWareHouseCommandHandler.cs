using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.WareHouseServices.Handlers.Commands.Base;
public class BaseWareHouseCommandHandler : BaseHandler
{
    protected internal IWareHouseRepository? Repository;
    public BaseWareHouseCommandHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.WareHouseRepository;
    }
}

