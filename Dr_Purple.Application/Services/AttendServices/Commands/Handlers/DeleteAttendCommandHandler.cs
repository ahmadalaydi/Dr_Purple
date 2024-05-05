using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands.Handlers;

public class DeleteAttendCommandHandler : IRequestHandler<DeleteAttendCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteAttendCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(DeleteAttendCommand command, CancellationToken cancellationToken)
    {
        var Attend = await UnitOfWork.AttendRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (Attend is null)
            return new ErrorResult(Messages.AttendNotFound, Messages.AttendNotFoundId);

        await UnitOfWork.AttendRepository.DeleteAsync(Attend);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.AttendDeleted, Messages.AttendDeletedId);
    }
}