using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class DeleteLeaveBalanceCommandHandler : IRequestHandler<DeleteLeaveBalanceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteLeaveBalanceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteLeaveBalanceCommand command, CancellationToken cancellationToken)
    {
        var LeaveBalance = await UnitOfWork.LeaveBalanceRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (LeaveBalance is null)
            return new ErrorResult(Messages.LeaveBalanceNotFound, Messages.LeaveBalanceNotFoundId);

        await UnitOfWork.LeaveBalanceRepository.DeleteAsync(LeaveBalance);
        await UnitOfWork.SaveChangesAsync();



        return new SuccsessResult(Messages.LeaveBalanceDeleted, Messages.LeaveBalanceDeletedId);
    }
}