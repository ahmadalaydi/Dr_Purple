using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.ServiceServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.ServiceServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Handlers.Queries;

public class ExistsServiceQueryHandler : BaseServiceQueryHandler,
    IRequestHandler<ExistsServiceQuery, IDataResult<ServiceResponse>>
{
    public ExistsServiceQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<ServiceResponse>> Handle(ExistsServiceQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<ServiceResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<ServiceResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<ServiceResponse>
            (new ServiceResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}