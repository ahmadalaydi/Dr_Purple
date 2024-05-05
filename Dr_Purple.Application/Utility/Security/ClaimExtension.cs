using System.Security.Claims;

namespace Dr_Purple.Application.Utility.Security;
public static class ClaimExtension
{
    public static void AddName(this ICollection<Claim> claims, string name)
    {
        claims.Add(new Claim(ClaimTypes.Name, name));
    }
    public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
    {
        claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
    }
    public static void AddRole(this ICollection<Claim> claims, string role)
    {
        claims.Add(new Claim(ClaimTypes.Role, role));
    }
    public static void AddProfilePicPath(this ICollection<Claim> claims, string profilePicPath)
    {
        claims.Add(new Claim("ProfilePicPath", profilePicPath));
    }
    public static void AddFCM_Key(this ICollection<Claim> claims, string fcm_key)
    {
        claims.Add(new Claim("FCM_Key", fcm_key));
    }
}

