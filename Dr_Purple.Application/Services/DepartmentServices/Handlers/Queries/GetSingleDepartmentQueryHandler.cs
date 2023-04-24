using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.DepartmentServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.DepartmentServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Handlers.Queries;

public class GetSingleDepartmentQueryHandler : BaseDepartmentQueryHandler,
    IRequestHandler<GetSingleDepartmentQuery, IDataResult<DepartmentResponse>>
{
    public GetSingleDepartmentQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<DepartmentResponse>> Handle(GetSingleDepartmentQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetSingleAsync(_ => _.UserName == request!.UserName);

        if (user is null)
        {
            return new ErrorDataResult<DepartmentResponse>(Messages.UserNotFound, Messages.UserNotFoundId);
        }
        if (!HashingHelper.VerifyPasswordHash(request!.Password, user.PasswordHash!, user.PasswordSalt!))
        {
            return new ErrorDataResult<DepartmentResponse>(Messages.PasswordError, Messages.PasswordErrorId);
        }

        return new SuccsessDataResult<DepartmentResponse>
            (new DepartmentResponse(user,
            JwtTokenGenerator!.GenerateAccessToken(user),
            user.RefreshToken),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}