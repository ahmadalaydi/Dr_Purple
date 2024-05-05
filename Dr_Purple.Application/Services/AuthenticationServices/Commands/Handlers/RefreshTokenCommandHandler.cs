using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Dr_Purple.Application.Services.AuthenticationServices.Commands.Handlers;

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, IResult>
{
    protected internal IJwtTokenGenerator JwtTokenGenerator;
    protected internal IConfiguration Configuration;
    private readonly IUnitOfWork UnitOfWork;
    public RefreshTokenCommandHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator, IConfiguration configuration)
    {
        UnitOfWork = unitOfWork;
        JwtTokenGenerator = jwtTokenGenerator;
        Configuration = configuration;
    }

    public async Task<IResult> Handle(RefreshTokenCommand command, CancellationToken cancellationToken)
    {
        string accessToken = command.AccessToken;
        string refreshToken = command.RefreshToken;

        var principal = JwtTokenGenerator!.GetPrincipalFromExpiredToken(accessToken);
        if (principal == null)
            return new ErrorResult(Messages.InvalidToken, Messages.InvalidTokenId);

        string username = principal.Identity!.Name!;
        var user = await UnitOfWork.UserRepository.GetFirstAsync(_ => _.UserName == username);

        if (user == null
            || user.RefreshToken != refreshToken
            || user.RefreshTokenExpiryTime <= DateTime.Now)
            return new ErrorResult(Messages.InvalidToken, Messages.InvalidTokenId);

        var newRefreshToken = JwtTokenGenerator.GenerateRefreshToken();

        user.UpdateRefreshToken(newRefreshToken);
        await UnitOfWork.UserRepository.UpdateAsync(user);
        await UnitOfWork.SaveChangesAsync();


        return new SuccsessDataResult<AuthResponse>(new AuthResponse(JwtTokenGenerator.GenerateAccessToken(user), newRefreshToken),
                    Messages.TokenRefreshed,
                    Messages.TokenRefreshedId);
    }
}