using Dr_Purple.Domain.Enums;

namespace Dr_Purple.Domain.Interfaces;
public interface IAuthenticatedUserService
{
    public string? UserId { get; }
    public string? FCM_Key { get; }
    //public string? Username { get; }
    //public string? ProfilePicture { get; }
    public Role Role { get; }
}