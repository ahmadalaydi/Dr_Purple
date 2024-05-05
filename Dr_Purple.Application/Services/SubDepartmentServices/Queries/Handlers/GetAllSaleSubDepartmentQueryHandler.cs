using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries.Handlers;

public class GetAllSaleSubDepartmentQueryHandler : IRequestHandler<GetAllSaleSubDepartmentQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllSaleSubDepartmentQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(GetAllSaleSubDepartmentQuery request, CancellationToken cancellationToken)
    {
        var SubDepartments = await Task.FromResult(UnitOfWork.SaleSubDepartmentRepository.GetAll()
            .Include(_=>_.Materials)
            .Sort(request.Options.OrderBy)
            .Search(request.Options.SearchBy)
            .GetPaged(request.Options.PageNo, request.Options.PageSize));

        return SubDepartments.PageCount > 0
            ? new SuccsessDataResult<PagedResult<SaleSubDepartment>>(SubDepartments, Messages.SubDepartmentListRetrieved, Messages.SubDepartmentListRetrievedId)
            : new ErrorResult(Messages.EmptySubDepartmentList, Messages.EmptySubDepartmentListId);
    }
}