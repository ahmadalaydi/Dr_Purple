using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands.Handlers;

public class UpdateAttendCommandHandler : IRequestHandler<UpdateAttendCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateAttendCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(UpdateAttendCommand command, CancellationToken cancellationToken)
    {
        var attend = await UnitOfWork.AttendRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (attend is null)
            return new ErrorResult(Messages.AttendNotFound, Messages.AttendNotFoundId);

        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        attend.Update(command.ContractId, command.StartDate, command.EndDate);
        await UnitOfWork.AttendRepository.UpdateAsync(attend);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Attend>(attend, Messages.AttendUpdated, Messages.AttendUpdatedId);
    }
}