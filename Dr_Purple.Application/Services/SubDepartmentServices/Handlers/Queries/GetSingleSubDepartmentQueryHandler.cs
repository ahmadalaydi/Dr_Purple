using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.SubDepartmentServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.SubDepartmentServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Handlers.Queries;

public class GetSingleSubDepartmentQueryHandler : BaseSubDepartmentQueryHandler,
    IRequestHandler<GetSingleSubDepartmentQuery, IDataResult<SubDepartmentResponse>>
{
    public GetSingleSubDepartmentQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<SubDepartmentResponse>> Handle(GetSingleSubDepartmentQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<SubDepartmentResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<SubDepartmentResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<SubDepartmentResponse>
            (new SubDepartmentResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}