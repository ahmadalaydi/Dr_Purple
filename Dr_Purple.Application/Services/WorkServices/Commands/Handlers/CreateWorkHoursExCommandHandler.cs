using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands.Handlers;

public class CreateWorkHoursExceptionCommandHandler : IRequestHandler<CreateWorkHoursExceptionCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateWorkHoursExceptionCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateWorkHoursExceptionCommand command, CancellationToken cancellationToken)
    {
        var workHoursException = WorkHoursException.Create(command.Name, command.StartDate, command.EndDate);
        await UnitOfWork.WorkHoursExceptionRepository.AddAsync(workHoursException);
        await UnitOfWork.SaveChangesAsync();


        return new SuccsessDataResult<WorkHoursException>(workHoursException, Messages.WorkHoursExceptionCreated, Messages.WorkHoursExceptionCreatedId);
    }
}