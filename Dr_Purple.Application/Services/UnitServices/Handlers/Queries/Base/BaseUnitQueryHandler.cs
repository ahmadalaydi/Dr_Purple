using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.UnitServices.Handlers.Queries.Base;
public class BaseUnitQueryHandler : BaseHandler
{
    protected internal IUnitRepository? Repository;
    public BaseUnitQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.UnitRepository;
    }
}
