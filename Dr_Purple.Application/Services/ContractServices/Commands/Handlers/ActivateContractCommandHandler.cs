using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Constants.Notification;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class ActivateContractCommandHandler : IRequestHandler<ActivateContractCommand, IResult>
{
    private readonly ITaskSettingsService TaskSettingsService;
    private readonly IUnitOfWork UnitOfWork;
    public ActivateContractCommandHandler(IUnitOfWork unitOfWork, ITaskSettingsService taskSettingsService)
    {
        UnitOfWork = unitOfWork;
        TaskSettingsService = taskSettingsService;
    }
    public async Task<IResult> Handle(ActivateContractCommand command, CancellationToken cancellationToken)
    {
        var contract = await Task.FromResult(UnitOfWork.ContractRepository
            .GetBy(_ => _.Id.Equals(command.Id))
            .Include(_=>_.ContractServices)
            .ThenInclude(_=>_.Service).AsSplitQuery().AsNoTracking()
            .Include(_=>_.Leaves).First());

        var WorkHoursException = UnitOfWork.WorkHoursExceptionRepository
                .GetBy(_ => _.StartDate.Date >= DateTime.UtcNow
                         && _.EndDate.Date <= DateTime.UtcNow.AddDays
                         (TaskSettingsService.GetTimeSlotGenerateDays()))
                         .AsNoTracking().AsEnumerable().ToList();

        var Temp = DateOnly.FromDateTime(DateTime.UtcNow);
        var holidays = UnitOfWork.HolidayRepository
            .GetBy(_ => _.Date > Temp
                     && _.Date < Temp.AddDays(TaskSettingsService.GetTimeSlotGenerateDays()))
                    .AsNoTracking().AsEnumerable().ToList();

        if (contract is null)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        if (contract.EndDate <= contract.StartDate)
            return new ErrorResult(Messages.ErrorInDate, Messages.ErrorInDateId);

        contract.State.Active(contract);

        await UnitOfWork.ServiceTimeRepository.AddRangeAsync(
                    ServiceTime.GenerateTimeSlots(contract,
                    TaskSettingsService.GetTimeSlotGenerateDays(),
                    DateTime.UtcNow,
                    WorkHoursException,
                    holidays));

        await UnitOfWork.ContractRepository.UpdateAsync(contract);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Contract>(contract, Messages.ContractUpdated, Messages.ContractUpdatedId);
    }
}