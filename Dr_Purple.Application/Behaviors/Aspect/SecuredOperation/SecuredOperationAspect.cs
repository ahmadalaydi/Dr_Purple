using Castle.DynamicProxy;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Exceptions;
using Dr_Purple.Application.Utility.Interceptors;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Dr_Purple.Application.Behaviors.Aspect.SecuredOperation;
public class SecuredOperationAspect : MethodInterseption
{
    private readonly string _role;
    private readonly IHttpContextAccessor? _httpContextAccessor;
    public SecuredOperationAspect(string role, IHttpContextAccessor httpContextAccessor)
        => (_role, _httpContextAccessor) = (role, httpContextAccessor);

    protected override void OnBefore(IInvocation? invocation)
    {
        if (!_httpContextAccessor!.HttpContext!.User.Identity!.IsAuthenticated)
            throw new AuthException(Messages.AuthenticationDenied, Messages.AuthenticationDeniedId);

        if (_role!.Equals(_httpContextAccessor.HttpContext.User.ClaimRoles()))
            return;

        throw new AuthException(Messages.AuthorizeationDenied, Messages.AuthorizeationDeniedId);
    }
}

