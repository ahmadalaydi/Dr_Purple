using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.OfferServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.OfferServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.OfferServices.Handlers.Queries;

public class GetFirstOfferQueryHandler : BaseOfferQueryHandler,
    IRequestHandler<GetFirstOfferQuery, IDataResult<OfferResponse>>
{
    public GetFirstOfferQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<OfferResponse>> Handle(GetFirstOfferQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<OfferResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<OfferResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<OfferResponse>
            (new OfferResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}