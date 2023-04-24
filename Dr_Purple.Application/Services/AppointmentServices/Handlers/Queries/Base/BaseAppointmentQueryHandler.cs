using Dr_Purple.Application.Services.Base;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.AppointmentServices.Handlers.Queries.Base;
public class BaseAppointmentQueryHandler : BaseHandler
{
    protected internal IAppointmentRepository? Repository;
    public BaseAppointmentQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.AppointmentRepository;
    }
}
