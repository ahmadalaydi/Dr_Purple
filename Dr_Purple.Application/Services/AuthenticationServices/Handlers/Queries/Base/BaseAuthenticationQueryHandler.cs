using Dr_Purple.Application.Services.Base;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.AuthenticationServices.Handlers.Queries.Base;
public class BaseAuthenticationQueryHandler : BaseHandler
{
    protected internal IJwtTokenGenerator? JwtTokenGenerator;
    protected internal IUserRepository? Repository;
    public BaseAuthenticationQueryHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.UserRepository;
        JwtTokenGenerator = provider!.GetService<IJwtTokenGenerator>();
    }
}
