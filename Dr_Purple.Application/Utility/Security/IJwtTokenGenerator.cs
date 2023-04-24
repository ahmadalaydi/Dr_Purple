using Dr_Purple.Domain.Entities.Users;

namespace Dr_Purple.Application.Utility.Security;

public interface IJwtTokenGenerator
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
}