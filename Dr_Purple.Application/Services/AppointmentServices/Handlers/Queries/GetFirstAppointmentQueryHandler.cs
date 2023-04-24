using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.AppointmentServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.AppointmentServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Handlers.Queries;

public class GetFirstAppointmentQueryHandler : BaseAppointmentQueryHandler,
    IRequestHandler<GetFirstAppointmentQuery, IDataResult<AppointmentResponse>>
{
    public GetFirstAppointmentQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<AppointmentResponse>> Handle(GetFirstAppointmentQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<AppointmentResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<AppointmentResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<AppointmentResponse>
            (new AppointmentResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}