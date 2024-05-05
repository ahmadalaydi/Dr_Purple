using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands.Handlers;

public class DeleteWorkHoursExceptionCommandHandler : IRequestHandler<DeleteWorkHoursExceptionCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteWorkHoursExceptionCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(DeleteWorkHoursExceptionCommand command, CancellationToken cancellationToken)
    {
        var WorkHoursException = await UnitOfWork.WorkHoursExceptionRepository.GetFirstAsync(_ => _.Id == command.Id);

        if (WorkHoursException is null)
            return new ErrorResult(Messages.WorkHoursExceptionNotFound, Messages.WorkHoursExceptionNotFoundId);

        await UnitOfWork.WorkHoursExceptionRepository.DeleteAsync(WorkHoursException);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.WorkHoursExceptionDeleted, Messages.WorkHoursExceptionDeletedId);
    }
}