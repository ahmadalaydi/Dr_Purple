using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands.Handlers;

public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public DeleteHolidayCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(DeleteHolidayCommand command, CancellationToken cancellationToken)
    {
        var Holiday = await UnitOfWork.HolidayRepository.GetFirstAsync(_ => _.Id == command.Id);

        if (Holiday is null)
            return new ErrorResult(Messages.HolidayNotFound, Messages.HolidayNotFoundId);

        await UnitOfWork.HolidayRepository.DeleteAsync(Holiday);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessResult(Messages.HolidayDeleted, Messages.HolidayDeletedId);
    }
}