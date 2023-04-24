using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.LeaveServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.LeaveServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Handlers.Queries;

public class GetByLeaveQueryHandler : BaseLeaveQueryHandler,
    IRequestHandler<GetByLeaveQuery, IDataResult<LeaveResponse>>
{
    public GetByLeaveQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<LeaveResponse>> Handle(GetByLeaveQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<LeaveResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<LeaveResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<LeaveResponse>
            (new LeaveResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}