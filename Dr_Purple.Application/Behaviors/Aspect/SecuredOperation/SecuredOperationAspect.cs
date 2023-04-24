using Castle.DynamicProxy;
using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Utility.Exceptions;
using Dr_Purple.Application.Utility.Interceptors;
using Dr_Purple.Application.Utility.Security;
using Microsoft.AspNetCore.Http;

namespace Dr_Purple.Application.Behaviors.Aspect.SecuredOperation;
public class SecuredOperationAspect : MethodInterseption
{
    private readonly string[]? _roles;
    private readonly IHttpContextAccessor? _httpContextAccessor;
    public SecuredOperationAspect(string roles, IHttpContextAccessor httpContextAccessor)
        => (_roles, _httpContextAccessor) = (roles.Split(","), httpContextAccessor);

    protected override void OnBefore(IInvocation? invocation)
    {
        if (!_httpContextAccessor!.HttpContext!.User.Identity!.IsAuthenticated)
            throw new AuthException(Messages.AuthenticationDenied, Messages.AuthenticationDeniedId);

        var roleClaim = _httpContextAccessor.HttpContext.User.ClaimRoles();

        Parallel.ForEach(roleClaim, role =>
        {
            if (_roles!.Contains(role))
                return;
        });

        throw new AuthException(Messages.AuthorizeationDenied, Messages.AuthorizeationDeniedId);
    }
}

