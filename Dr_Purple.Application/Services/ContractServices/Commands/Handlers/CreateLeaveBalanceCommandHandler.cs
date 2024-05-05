using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class CreateLeaveBalanceCommandHandler : IRequestHandler<CreateLeaveBalanceCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateLeaveBalanceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateLeaveBalanceCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        var leaveBalance = LeaveBalance.Create(command.ContractId, command.StartDate, command.EndDate, command.Balance);

        await UnitOfWork.LeaveBalanceRepository.AddAsync(leaveBalance);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<LeaveBalance>(leaveBalance, Messages.LeaveBalanceCreated, Messages.LeaveBalanceCreatedId);
    }
}