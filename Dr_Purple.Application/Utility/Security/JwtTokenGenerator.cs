using Dr_Purple.Domain.Entities.Users;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Dr_Purple.Application.Utility.Security;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly JwtSettings _jwtSettings;

    public JwtTokenGenerator(IOptions<JwtSettings> jwtOptions)
    => _jwtSettings = jwtOptions!.Value;

    public string GenerateAccessToken(User? user)
    {
        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_jwtSettings!.Secret)),
            SecurityAlgorithms.HmacSha256);

        return new JwtSecurityTokenHandler().WriteToken(CreateJwtSecurityToken(user, signingCredentials));
    }

    public JwtSecurityToken CreateJwtSecurityToken(User? user, SigningCredentials signingCredentials)
    {
        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings!.Issuer,
            audience: _jwtSettings.Audience,
            expires: DateTime.UtcNow.AddHours(_jwtSettings.ExpiryMinutes),
            notBefore: DateTime.Now,
            claims: SetClaim(user),
            signingCredentials: signingCredentials
            );
        return jwt;
    }

    private static IEnumerable<Claim> SetClaim(User? user)
    {
        var claims = new List<Claim>();
        claims.AddNameIdentifier(user!.Id.ToString()!);
        claims.AddFCM_Key(user.FCM_Key);
        //claims.AddName(user.UserName!);
        claims.AddRole(user.Role.ToString()!);
        //claims.AddProfilePicPath(user.ProfilePicPath!);
        return claims;
    }

    public string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using var rng = RandomNumberGenerator.Create();
        rng.GetBytes(randomNumber);
        return Convert.ToBase64String(randomNumber);
    }

    public ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false,
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
            ValidateLifetime = false
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
        if (securityToken is not JwtSecurityToken jwtSecurityToken
        || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            return null;

        return principal;
    }
}