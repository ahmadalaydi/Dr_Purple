using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.WorkServices.Commands.Handlers;

public class CreateHolidayCommandHandler : IRequestHandler<CreateHolidayCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateHolidayCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;

    public async Task<IResult> Handle(CreateHolidayCommand command, CancellationToken cancellationToken)
    {
        var holiday = Holiday.Create(command.Name, command.Date);
        await UnitOfWork.HolidayRepository.AddAsync(holiday);
        await UnitOfWork.SaveChangesAsync();


        return new SuccsessDataResult<Holiday>(holiday, Messages.HolidayCreated, Messages.HolidayCreatedId);
    }
}