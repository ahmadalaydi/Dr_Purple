using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.UnitServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.UnitServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.UnitServices.Handlers.Queries;

public class GetAllUnitQueryHandler : BaseUnitQueryHandler,
    IRequestHandler<GetAllUnitQuery, IDataResult<UnitResponse>>
{
    public GetAllUnitQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<UnitResponse>> Handle(GetAllUnitQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<UnitResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<UnitResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<UnitResponse>
            (new UnitResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}