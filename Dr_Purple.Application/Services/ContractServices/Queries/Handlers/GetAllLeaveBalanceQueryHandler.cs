using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetAllLeaveBalanceQueryHandler : IRequestHandler<GetAllLeaveBalanceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetAllLeaveBalanceQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetAllLeaveBalanceQuery request, CancellationToken cancellationToken)
    {
        var LeaveBalances = await Task.FromResult(UnitOfWork.LeaveBalanceRepository.GetAll().Sort(request.Options.OrderBy).Search(request.Options.SearchBy).GetPaged(request.Options.PageNo, request.Options.PageSize));

        return LeaveBalances.PageCount > 0
            ? new SuccsessDataResult<PagedResult<LeaveBalance>>(LeaveBalances, Messages.LeaveBalanceListRetrieved, Messages.LeaveBalanceListRetrievedId)
            : new ErrorResult(Messages.EmptyLeaveBalanceList, Messages.EmptyLeaveBalanceListId);
    }
}