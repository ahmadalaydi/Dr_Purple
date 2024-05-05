using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries.Handlers;

public class GetAllAdministrativeSubDepartmentQueryHandler : IRequestHandler<GetAllAdministrativeSubDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllAdministrativeSubDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllAdministrativeSubDepartmentQuery request, CancellationToken cancellationToken)
    {
        var SubDepartments = await Task.FromResult(UnitOfWork.AdministrativeSubDepartmentRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return SubDepartments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<AdministrativeSubDepartment>>(SubDepartments, Messages.SubDepartmentListRetrieved, Messages.SubDepartmentListRetrievedId)
            : new ErrorResult(Messages.EmptySubDepartmentList, Messages.EmptySubDepartmentListId);
    }
}