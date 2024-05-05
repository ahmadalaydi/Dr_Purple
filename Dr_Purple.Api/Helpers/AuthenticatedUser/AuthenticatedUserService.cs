using Dr_Purple.Domain.Enums;
using Dr_Purple.Domain.Interfaces;
using System.Security.Claims;

namespace Dr_Purple.Api.Helpers.AuthenticatedUser;
public class AuthenticatedUserService : IAuthenticatedUserService
{
    public string? UserId { get; }
    public string? FCM_Key { get; }
    //public string? Username { get; }
    //public string? ProfilePicture { get; }
    public Role Role { get; }
    public AuthenticatedUserService(IHttpContextAccessor httpContextAccessor)
    {
        UserId = httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.NameIdentifier)?.Value!;

        FCM_Key = httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.NameIdentifier)?.Value!;
        //Username = httpContextAccessor.HttpContext?.User?
        //          .FindFirst(ClaimTypes.Name)?.Value!;

        //ProfilePicture = httpContextAccessor.HttpContext?.User?
        //                .FindFirst("ProfilePicPath")?.Value!;
        var role = httpContextAccessor.HttpContext?.User?
              .FindFirst(ClaimTypes.Role)?.Value!;

        if (role is not null)
            Role = Enum.Parse<Role>(role);
    }
}