using Dr_Purple.Application.Services.Base;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.AttendServices.Handlers.Queries.Base;
public class BaseAttendQueryHandler : BaseHandler
{
    protected internal IAttendRepository? Repository;
    public BaseAttendQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.AttendRepository;
    }
}
