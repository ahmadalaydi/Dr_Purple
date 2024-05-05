using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands.Handlers;

public class DeleteLeaveCommandHandler : IRequestHandler<DeleteLeaveCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteLeaveCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteLeaveCommand command, CancellationToken cancellationToken)
    {
        var Leave = await UnitOfWork.LeaveRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (Leave is null)
            return new ErrorResult(Messages.LeaveNotFound, Messages.LeaveNotFoundId);

        await UnitOfWork.LeaveRepository.DeleteAsync(Leave);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.LeaveDeleted, Messages.LeaveDeletedId);
    }
}