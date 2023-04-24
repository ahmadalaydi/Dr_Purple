using Dr_Purple.Application.Constants;
using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Services.DepartmentServices.Handlers.Queries.Base;
using Dr_Purple.Application.Services.DepartmentServices.Queries;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Application.Utility.Security;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Handlers.Queries;

public class GetFirstDepartmentQueryHandler : BaseDepartmentQueryHandler,
    IRequestHandler<GetFirstDepartmentQuery, IDataResult<DepartmentResponse>>
{
    public GetFirstDepartmentQueryHandler(IServiceProvider provider) : base(provider) { }

    public async Task<IDataResult<DepartmentResponse>> Handle(GetFirstDepartmentQuery? request, CancellationToken cancellationToken)
    {
        var user = await Repository!.GetFirstAsync(_ => _.UserName == request!.UserName);

        return new SuccsessDataResult<DepartmentResponse>
            (new DepartmentResponse(user),
            Messages.SuccessfulLogin,
            Messages.SuccessfulLoginId);
    }
}