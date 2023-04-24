using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AuthenticationServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.AuthenticationServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Handlers.Queries;

public class LoginQueryHandler : BaseAuthenticationQueryHandler,
    IRequestHandler<LoginQuery, IDataResult<AuthenticationResponse>>
{
    public LoginQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<AuthenticationResponse>> Handle(LoginQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<AuthenticationResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<AuthenticationResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<AuthenticationResponse>
            (new AuthenticationResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}