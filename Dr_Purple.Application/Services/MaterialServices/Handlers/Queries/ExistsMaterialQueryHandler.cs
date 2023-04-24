using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.MaterialServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.MaterialServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Handlers.Queries;

public class ExistsMaterialQueryHandler : BaseMaterialQueryHandler,
    IRequestHandler<ExistsMaterialQuery, IDataResult<MaterialResponse>>
{
    public ExistsMaterialQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<MaterialResponse>> Handle(ExistsMaterialQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<MaterialResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<MaterialResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<MaterialResponse>
            (new MaterialResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}