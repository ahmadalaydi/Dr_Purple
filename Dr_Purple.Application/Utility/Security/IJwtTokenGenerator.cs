using Dr_Purple.Domain.Entities.Users;
using System.Security.Claims;

namespace Dr_Purple.Application.Utility.Security;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token);
}