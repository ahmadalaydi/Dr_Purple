using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Queries.Handlers;

public class GetAllDepartmentQueryHandler : IRequestHandler<GetAllDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllDepartmentQuery request, CancellationToken cancellationToken)
    {
        var Departments = await Task.FromResult(UnitOfWork.DepartmentRepository.GetAll()
            //.Include(_=>_.SubDepartments)
            //.Include(_ => _.Contracts)
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo,
            request.Options.PageSize));

        return Departments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Department>>(Departments, Messages.DepartmentListRetrieved, Messages.DepartmentListRetrievedId)
            : new ErrorResult(Messages.EmptyDepartmentList, Messages.EmptyDepartmentListId);
    }
}