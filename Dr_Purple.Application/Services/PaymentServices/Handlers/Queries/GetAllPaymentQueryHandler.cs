using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.PaymentServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.PaymentServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.PaymentServices.Handlers.Queries;

public class GetAllPaymentQueryHandler : BasePaymentQueryHandler,
    IRequestHandler<GetAllPaymentQuery, IDataResult<PaymentResponse>>
{
    public GetAllPaymentQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<PaymentResponse>> Handle(GetAllPaymentQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<PaymentResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<PaymentResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<PaymentResponse>
            (new PaymentResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}