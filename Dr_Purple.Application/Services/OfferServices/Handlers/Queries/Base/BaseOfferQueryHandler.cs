using Dr_Purple.Application.Services.Base;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.OfferServices.Handlers.Queries.Base;
public class BaseOfferQueryHandler : BaseHandler
{
    protected internal IOfferRepository? Repository;
    public BaseOfferQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.OfferRepository;
    }
}
