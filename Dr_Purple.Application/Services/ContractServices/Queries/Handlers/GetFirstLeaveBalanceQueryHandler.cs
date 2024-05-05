using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries.Handlers;

public class GetFirstLeaveBalanceQueryHandler : IRequestHandler<GetFirstLeaveBalanceQuery, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public GetFirstLeaveBalanceQueryHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(GetFirstLeaveBalanceQuery request, CancellationToken cancellationToken)
    {
        var leaveBalance = await UnitOfWork.LeaveBalanceRepository.GetFirstAsync(_ => _.Id == request.Id);

        return leaveBalance is null
            ? new ErrorResult(Messages.LeaveBalanceNotFound, Messages.LeaveBalanceNotFoundId)
            : new SuccsessDataResult<LeaveBalance>(leaveBalance, Messages.LeaveBalanceExists, Messages.LeaveBalanceExistsId);
    }
}