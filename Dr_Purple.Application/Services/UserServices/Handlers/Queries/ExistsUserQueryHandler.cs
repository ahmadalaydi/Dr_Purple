using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.UserServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.UserServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Handlers.Queries;

public class ExistsUserQueryHandler : BaseUserQueryHandler,
    IRequestHandler<ExistsUserQuery, IDataResult<UserResponse>>
{
    public ExistsUserQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<UserResponse>> Handle(ExistsUserQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<UserResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<UserResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<UserResponse>
            (new UserResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}