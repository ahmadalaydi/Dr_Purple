using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.PaymentServices.Handlers.Queries.Base;
public class BasePaymentQueryHandler : BaseHandler
{
    protected internal IPaymentRepository? Repository;
    public BasePaymentQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.PaymentRepository;
    }
}