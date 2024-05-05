using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Infrastructure.Repositories;
public class ServiceTimeRepository : BaseRepository<ServiceTime>, IServiceTimeRepository
{
    //private readonly DbSet<WorkHoursException> _dbSetWorkHoursException;
    //private readonly DbSet<ServiceTime> _dbSetServiceTime;
    //private readonly DbSet<Holiday> _dbSetHoliday;
    //private readonly DbSet<Service> _dbSetService;

    public ServiceTimeRepository(AppDbContext dbContext) : base(dbContext)
    {
        //_dbSetServiceTime = dbContext.Set<ServiceTime>();
        //_dbSetWorkHoursException = dbContext.Set<WorkHoursException>();
        //_dbSetHoliday = dbContext.Set<Holiday>();
        //_dbSetService = dbContext.Set<Service>();
    }

    //public async void GenerateTimeSlots(Contract contract, int interval, DateTime date)
    //{
    //    await Task.WhenAll();
    //    HashSet<ServiceTime> serviceTimes = new();

    //    var workHoursExceptions = GetWorkHoursExceptions(date, interval);
    //    var leaves = GetLeaves(contract.Leaves.AsQueryable(), date, date.AddDays(interval));
    //    var holidays = GetHolidays(date, interval);

    //    foreach (var contractService in contract.ContractServices)
    //    {
    //        var service = await _dbSetService.FirstAsync(_ => _.Id == contractService.ServiceId);
    //        var duration = service.Duration;
    //        var time = contractService.StartTime;

    //        while (DateOnly.FromDateTime(date) <= contract.EndDate) // use DateOnly.FromDateTime here
    //        {
    //            if (IsWorkingDay(date, holidays, contractService.Day))
    //            {
    //                while (time < contractService.EndTime)
    //                {
    //                    if (IsAvailableSlot(date, time, duration, workHoursExceptions, leaves))
    //                    {
    //                        serviceTimes.Add(ServiceTime.
    //                            Create(contractService.ServiceId,
    //                                   contract.Id, DateOnly.FromDateTime(date), // use DateOnly.FromDateTime here
    //                                   time, time.Add(duration)));
    //                    }
    //                    time = time.Add(duration);
    //                }
    //            }
    //            date = date.AddDays(1);
    //        }
    //    }
    //    _dbSetServiceTime.AddRange(serviceTimes);
    //}

    //private List<WorkHoursException> GetWorkHoursExceptions(DateTime date, int interval)
    //{
    //    return _dbSetWorkHoursException.Where(_
    //                            => _.StartDate.Date >= date
    //                            && _.EndDate.Date <= date.AddDays(interval))
    //                            .AsNoTracking().AsEnumerable().ToList();
    //}

    //private static List<Leave> GetLeaves(IQueryable<Leave> leaves, DateTime startDate, DateTime endDate)
    //{
    //    return leaves.Where(_ => _.State == new ApprovedLeaveState()
    //                 && _.StartDate.Date >= startDate
    //                 && _.EndDate.Date <= endDate).AsNoTracking().AsEnumerable().ToList();
    //}

    //private List<Holiday> GetHolidays(DateTime date, int interval)
    //{
    //    return _dbSetHoliday.Where(_
    //        => _.Date > DateOnly.FromDateTime(date)
    //        && _.Date < DateOnly.FromDateTime(date.AddDays(interval)))
    //        .AsNoTracking().AsEnumerable().ToList();
    //}

    //private static bool IsWorkingDay(DateTime date, List<Holiday> holidays, DayOfWeek day)
    //{
    //    return !holidays.Any(holiday => holiday.Date == DateOnly.FromDateTime(date))
    //              && date.DayOfWeek.Equals(day);
    //}

    //private static bool IsAvailableSlot(DateTime date, TimeSpan time, TimeSpan duration,
    //                                    List<WorkHoursException> workHoursExceptions,
    //                                    List<Leave> leaves)
    //{
    //    return !workHoursExceptions.Any(workHour => workHour.StartDate.Date == date
    //                        && workHour.StartDate.TimeOfDay >= time && workHour.EndDate.TimeOfDay <= time.Add(duration))
    //                        || leaves.Any(leave => leave.StartDate.Date == date
    //                        && leave.StartDate.TimeOfDay >= time && leave.EndDate.TimeOfDay <= time.Add(duration));
    //}
}