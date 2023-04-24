using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.ContractServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.ContractServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Handlers.Queries;

public class GetByContractQueryHandler : BaseContractQueryHandler,
    IRequestHandler<GetByContractQuery, IDataResult<ContractResponse>>
{
    public GetByContractQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<ContractResponse>> Handle(GetByContractQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<ContractResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<ContractResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<ContractResponse>
            (new ContractResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}