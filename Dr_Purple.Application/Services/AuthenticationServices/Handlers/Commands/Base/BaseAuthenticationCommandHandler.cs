using Dr_Purple.Application.Services.Base;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using MapsterMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.AuthenticationServices.Handlers.Commands.Base;
public class BaseAuthenticationCommandHandler : BaseHandler
{

    protected internal IJwtTokenGenerator? JwtTokenGenerator;
    protected internal IConfiguration? Configuration;
    protected internal IUserRepository? Repository;
    public BaseAuthenticationCommandHandler(IServiceProvider? provider)
    : base(provider!.GetService<IUnitOfWork>(), provider!.GetService<IMapper>())
    {
        Repository = UnitOfWork!.UserRepository;
        JwtTokenGenerator = provider!.GetService<IJwtTokenGenerator>();
        Configuration = provider!.GetService<IConfiguration>();
    }
}

