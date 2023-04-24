using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.WareHouseServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.WareHouseServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.WareHouseServices.Handlers.Queries;

public class GetSingleWareHouseQueryHandler : BaseWareHouseQueryHandler,
    IRequestHandler<GetSingleWareHouseQuery, IDataResult<WareHouseResponse>>
{
    public GetSingleWareHouseQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<WareHouseResponse>> Handle(GetSingleWareHouseQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<WareHouseResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<WareHouseResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<WareHouseResponse>
            (new WareHouseResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}