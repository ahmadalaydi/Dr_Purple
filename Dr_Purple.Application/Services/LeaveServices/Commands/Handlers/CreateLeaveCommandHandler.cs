using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands.Handlers;

public class CreateLeaveCommandHandler : IRequestHandler<CreateLeaveCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateLeaveCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateLeaveCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id.Equals(command.ContractId)) is false)
            return new ErrorResult(Messages.ContractNotFoundId, Messages.ContractNotFoundId);

        var leave = Leave.Create(command.ContractId, command.StartDate, command.EndtDate);

        await UnitOfWork.LeaveRepository.AddAsync(leave);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Leave>(leave, Messages.LeaveCreated, Messages.LeaveCreatedId);
    }
}