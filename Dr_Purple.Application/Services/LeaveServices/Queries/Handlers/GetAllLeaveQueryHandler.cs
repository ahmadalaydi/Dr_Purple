using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Queries.Handlers;

public class GetAllLeaveQueryHandler : IRequestHandler<GetAllLeaveQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllLeaveQueryHandler(IUnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
    }

    public async Task<IResult> Handle(GetAllLeaveQuery request, CancellationToken cancellationToken)
    {
        var Leaves = await Task.FromResult(UnitOfWork.LeaveRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return Leaves.PageCount > 0
            ? new SuccsessDataResult<PagedResult<Leave>>(Leaves, Messages.LeaveListRetrieved, Messages.LeaveListRetrievedId)
            : new ErrorResult(Messages.EmptyLeaveList, Messages.EmptyLeaveListId);
    }
}