using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands.Handlers;

public class UpdateHolidayCommandHandler : IRequestHandler<UpdateHolidayCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public UpdateHolidayCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(UpdateHolidayCommand command, CancellationToken cancellationToken)
    {
        var holiday = await UnitOfWork.HolidayRepository.GetFirstAsync(_ => _.Id == command.Id);
        if (holiday is null)
            return new ErrorResult(Messages.HolidayNotFound, Messages.HolidayNotFoundId);

        holiday!.Update(command.Name, command.Date);
        await UnitOfWork.HolidayRepository.UpdateAsync(holiday);
        await UnitOfWork.SaveChangesAsync();
        return new SuccsessDataResult<Holiday>(holiday, Messages.HolidayUpdated, Messages.HolidayUpdatedId);
    }
}