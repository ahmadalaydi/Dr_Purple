using Dr_Purple.Domain.Entities.Users;

namespace Dr_Purple.Application.Mapper.Response;
public record AuthenticationResponse(User? User, string? AccessToken, string? RefreshToken);