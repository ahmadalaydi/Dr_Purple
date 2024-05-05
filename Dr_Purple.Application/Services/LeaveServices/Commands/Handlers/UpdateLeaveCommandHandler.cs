using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands.Handlers;

public class UpdateLeaveCommandHandler : IRequestHandler<UpdateLeaveCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateLeaveCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork; public async Task<IResult> Handle(UpdateLeaveCommand command, CancellationToken cancellationToken)
    {
        var leave = await UnitOfWork.LeaveRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (leave is null)
            return new ErrorResult(Messages.LeaveNotFound, Messages.LeaveNotFoundId);

        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFoundId, Messages.ContractNotFoundId);

        leave.Update(command.ContractId, command.StartDate, command.EndtDate);

        await UnitOfWork.LeaveRepository.UpdateAsync(leave);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Leave>(leave, Messages.LeaveUpdated, Messages.LeaveUpdatedId);
    }
}