using System.Security.Claims;

namespace Dr_Purple.Application.Utility.Security;
public static class ClaimsPrincipalExtensions
{
    public static string Claims(this ClaimsPrincipal claimsPrincipal, string claimType)
        => claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).First()!;

    public static string ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        => claimsPrincipal?.Claims(ClaimTypes.Role)!;
}

