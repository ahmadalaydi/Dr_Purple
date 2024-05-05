using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Queries.Handlers;

public class LoginQueryHandler : IRequestHandler<LoginQuery, IResult>
{
    protected internal IJwtTokenGenerator JwtTokenGenerator;
    private readonly IUnitOfWork UnitOfWork;
    public LoginQueryHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
    {
        UnitOfWork = unitOfWork;
        JwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<IResult> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await UnitOfWork.UserRepository
            .GetFirstAsync(_ => _.UserName.Equals(request.UserName) && _.IsVerified);

        if (user is null)
            return new ErrorResult(Messages.UserNotFound, Messages.UserNotFoundId);

        if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash!, user.PasswordSalt!))
            return new ErrorResult(Messages.PasswordError, Messages.PasswordErrorId);

        return new SuccsessDataResult<AuthResponse>(new AuthResponse(JwtTokenGenerator!.GenerateAccessToken(user), user.RefreshToken!),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}