using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class UpdateLeaveBalanceCommandHandler : IRequestHandler<UpdateLeaveBalanceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateLeaveBalanceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateLeaveBalanceCommand command, CancellationToken cancellationToken)
    {
        var leaveBalance = await UnitOfWork.LeaveBalanceRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (leaveBalance is null)
            return new ErrorResult(Messages.LeaveBalanceNotFound, Messages.LeaveBalanceNotFoundId);

        leaveBalance.Update(command.ContractId, command.StartDate, command.EndDate, command.Balance);
        await UnitOfWork.LeaveBalanceRepository.UpdateAsync(leaveBalance);
        await UnitOfWork.SaveChangesAsync();


        return new SuccsessDataResult<LeaveBalance>(leaveBalance, Messages.LeaveBalanceUpdated, Messages.LeaveBalanceUpdatedId);
    }
}