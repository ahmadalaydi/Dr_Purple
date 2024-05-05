using Dr_Purple.Application.Constants.Messagess;

using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands.Handlers;

public class CreateAttendCommandHandler : IRequestHandler<CreateAttendCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateAttendCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<IResult> Handle(CreateAttendCommand command, CancellationToken cancellationToken)
    {
        if (await UnitOfWork.ContractRepository.ExistsAsync(_ => _.Id == command.ContractId) is false)
            return new ErrorResult(Messages.ContractNotFoundId, Messages.ContractNotFoundId);

        var attend = Attend.Create(command.ContractId, command.StartDate, command.EndDate);
        await UnitOfWork.AttendRepository.AddAsync(attend);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Attend>(attend, Messages.AttendCreated, Messages.AttendCreatedId);
    }
}