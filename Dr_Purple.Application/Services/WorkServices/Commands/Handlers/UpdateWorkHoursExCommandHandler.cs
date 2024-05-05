using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands.Handlers;

public class UpdateWorkHoursExceptionCommandHandler : IRequestHandler<UpdateWorkHoursExceptionCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateWorkHoursExceptionCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateWorkHoursExceptionCommand command, CancellationToken cancellationToken)
    {
        var workHoursException = await UnitOfWork.WorkHoursExceptionRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (workHoursException is null)
            return new ErrorResult(Messages.WorkHoursExceptionNotFound, Messages.WorkHoursExceptionNotFoundId);

        workHoursException!.Update(command.Name, command.StartDate, command.EndDate);
        await UnitOfWork.WorkHoursExceptionRepository.UpdateAsync(workHoursException);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<WorkHoursException>(workHoursException, Messages.WorkHoursExceptionUpdated, Messages.WorkHoursExceptionUpdatedId);
    }
}