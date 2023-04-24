using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.OrderServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.OrderServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.OrderServices.Handlers.Queries;

public class ExistsOrderQueryHandler : BaseOrderQueryHandler,
    IRequestHandler<ExistsOrderQuery, IDataResult<OrderResponse>>
{
    public ExistsOrderQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<OrderResponse>> Handle(ExistsOrderQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<OrderResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<OrderResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<OrderResponse>
            (new OrderResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}