using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AdditionServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.AdditionServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Handlers.Queries;

public class GetSingleAdditionQueryHandler : BaseAdditionQueryHandler,
    IRequestHandler<GetSingleAdditionQuery, IDataResult<AdditionResponse>>
{
    public GetSingleAdditionQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<AdditionResponse>> Handle(GetSingleAdditionQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<AdditionResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<AdditionResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<AdditionResponse>
            (new AdditionResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}