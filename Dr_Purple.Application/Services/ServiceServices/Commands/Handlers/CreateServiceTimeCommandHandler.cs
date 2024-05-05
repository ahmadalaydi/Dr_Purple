using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Contracts.ContractStatus;
using Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Infrastructure.Repositories.Base;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Application.Services.ServiceServices.Commands.Handlers;
public class CreateServiceTimeCommandHandler : IRequestHandler<CreateServiceTimeCommand, Unit>
{
    private readonly IServiceProvider ServiceProvider;

    public CreateServiceTimeCommandHandler(IServiceProvider serviceProvider)
    => ServiceProvider = serviceProvider;
    public async Task<Unit> Handle(CreateServiceTimeCommand command, CancellationToken cancellationToken)
    {
        using (IServiceScope scope = ServiceProvider.CreateScope())
        {
            IUnitOfWork UnitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
            var ActiveContracts = await Task.FromResult(UnitOfWork.ContractRepository
                .GetBy(_ => _.State == new ActiveContractState()).AsSplitQuery().AsNoTracking()
                .Include(_ => _.ContractServices)
                .ThenInclude(_=>_.Service).AsSplitQuery().AsNoTracking()
                .Include(_ => _.Leaves).AsSplitQuery().AsNoTracking());

            var WorkHoursException = UnitOfWork.WorkHoursExceptionRepository
                .GetBy(_ => _.StartDate.Date >= DateTime.UtcNow
                         && _.EndDate.Date <= DateTime.UtcNow.AddDays(command.Interval))
                         .AsNoTracking().AsEnumerable().ToList();

            var Temp = DateOnly.FromDateTime(DateTime.UtcNow);
            var holidays = UnitOfWork.HolidayRepository
                .GetBy(_ => _.Date > Temp
                         && _.Date < Temp.AddDays(command.Interval))
                        .AsNoTracking().AsEnumerable().ToList();

            foreach (var contract in ActiveContracts)
            {
                await UnitOfWork.ServiceTimeRepository.AddRangeAsync(
                    ServiceTime.GenerateTimeSlots(contract,
                    command.Interval,
                    DateTime.UtcNow,
                    WorkHoursException,
                    holidays));
            }
            await UnitOfWork.SaveChangesAsync();

        }
        return await Task.FromResult(Unit.Value);
    }


    //public async Task<Unit> Handle(CreateServiceTimeCommand command, CancellationToken cancellationToken)
    //{
    //    using (IServiceScope scope = ServiceProvider.CreateScope())
    //    {
    //        IUnitOfWork scopedUnitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
    //        var ActiveContracts = await Task.FromResult(scopedUnitOfWork.ContractRepository
    //        .GetBy(_ => _.State == new ActiveContractState()).AsSplitQuery().AsNoTracking()
    //        .Include(_ => _.ContractServices).AsSplitQuery().AsNoTracking()
    //        .Include(_ => _.Leaves).AsSplitQuery().AsNoTracking());

    //        foreach (var contract in ActiveContracts)
    //        {
    //            //scopedUnitOfWork.ServiceTimeRepository.GenerateTimeSlots(
    //            //    contract, command.Interval, DateTime.UtcNow);

    //            //await scopedUnitOfWork.ServiceTimeRepository.GenerateTimeSlots(contract, command.Interval, DateTime.UtcNow);

    //            await scopedUnitOfWork.ServiceTimeRepository.AddRangeAsync(
    //                await GenerateTimeSlots(contract, command.Interval, DateTime.UtcNow));
    //        }
    //        await scopedUnitOfWork.SaveChangesAsync();
    //    }
    //    return await Task.FromResult(Unit.Value);
    //}
    //public async Task<ICollection<ServiceTime>> GenerateTimeSlots(Contract contract, int interval, DateTime Date)
    //{
    //    HashSet<ServiceTime> serviceTimes = new();

    //    using (IServiceScope scope = ServiceProvider.CreateScope())
    //    {
    //        IUnitOfWork scopedUnitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
    //        var WorkHoursException = scopedUnitOfWork.WorkHoursExceptionRepository.GetBy(_
    //                            => _.StartDate.Date >= Date
    //                            && _.EndDate.Date <= Date.AddDays(interval))
    //                            .AsNoTracking().AsEnumerable().ToList();

    //        var leaves = GetLeaves(contract.Leaves.AsQueryable().AsNoTracking(), Date, Date.AddDays(interval));

    //        var holidays = scopedUnitOfWork.HolidayRepository.GetBy(_ => _.Date > DateOnly.FromDateTime(Date)
    //        && _.Date < DateOnly.FromDateTime(Date.AddDays(interval)))
    //            .AsNoTracking().AsEnumerable().ToList();

    //        foreach (var contractService in contract.ContractServices)
    //        {
    //            var service = await scopedUnitOfWork.ServiceRepository
    //                .GetFirstAsync(_ => _.Id == contractService.ServiceId);
    //            var duration = service.Duration;
    //            TimeSpan Time = contractService.StartTime;
    //            while (DateOnly.FromDateTime(Date) <= contract.EndDate)
    //            {
    //                if (!holidays.Any(holiday => holiday.Date == DateOnly.FromDateTime(Date))
    //                  && Date.DayOfWeek.Equals(contractService.Day))
    //                {
    //                    while (Time < contractService.EndTime)
    //                    {
    //                        if (!WorkHoursException.Any(workHour => workHour.StartDate.Date == Date
    //                            && workHour.StartDate.TimeOfDay >= Time && workHour.EndDate.TimeOfDay <= Time.Add(duration))
    //                            || leaves.Any(leave => leave.StartDate.Date == Date
    //                            && leave.StartDate.TimeOfDay >= Time && leave.EndDate.TimeOfDay <= Time.Add(duration)))
    //                        {
    //                            serviceTimes.Add(ServiceTime.
    //                                Create(contractService.ServiceId,
    //                                       contract.Id, DateOnly.FromDateTime(Date),
    //                                       Time, Time.Add(duration)));
    //                        }
    //                        Time = Time.Add(duration);
    //                    }
    //                }
    //                Date = Date.AddDays(1);
    //            }
    //        }
    //    }
    //    return serviceTimes;
    //}
    //private static IEnumerable<Leave> GetLeaves(IQueryable<Leave> leaves, DateTime StartDate, DateTime EndDate)
    //    => leaves.Where(_ => _.State == new ApprovedLeaveState()
    //                 && _.StartDate.Date >= StartDate
    //                 && _.EndDate.Date <= EndDate).AsEnumerable().ToList();
}