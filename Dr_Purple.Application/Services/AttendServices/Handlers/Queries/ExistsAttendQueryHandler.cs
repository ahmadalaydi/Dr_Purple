using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AttendServices.Queries;
using Dr_Purple.Application.Services.AttendServices.Handlers.Queries.Base;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Handlers.Queries;

public class ExistsAttendQueryHandler : BaseAttendQueryHandler,
    IRequestHandler<ExistsAttendQuery, IDataResult<AttendResponse>>
{
    public ExistsAttendQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<AttendResponse>> Handle(ExistsAttendQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<AttendResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<AttendResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<AttendResponse>
            (new AttendResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}