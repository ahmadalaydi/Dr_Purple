using Dr_Purple.Application.Services.Base;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.OfferServices.Handlers.Commands.Base;
public class BaseOfferCommandHandler : BaseHandler
{

    protected internal IOfferRepository? Repository;
    public BaseOfferCommandHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.OfferRepository;
    }
}

