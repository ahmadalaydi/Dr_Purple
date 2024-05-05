using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
using Dr_Purple.Domain.Entities.Services.Interfaces;
using Dr_Purple.Domain.Entities.Services.State;
using Dr_Purple.Domain.Entities.Works;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace Dr_Purple.Domain.Entities.Services;
[NotAuditable]
public class ServiceTime : IServiceTime
{
    public long Id { get; private set; }
    public long ServiceId { get; private set; }
    public long ContractServiceId { get; private set; }
    public DateOnly Date { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public IServiceTimeState State { get; private set; }

    [JsonIgnore]
    public virtual ContractService? ContractService { get; private set; }

    [JsonIgnore]
    public virtual Service? Service { get; private set; }

    [JsonIgnore]
    public virtual Appointment? Appointment { get; private set; }

    private ServiceTime(long serviceId, long contracServiceId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
    {
        State = new FreeServiceTimeState();
        ServiceId = serviceId;
        ContractServiceId = contracServiceId;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        State = new FreeServiceTimeState();
    }

    public ServiceTime()
    {
    }

    public static ServiceTime Create(long serviceId, long contracServiceId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
        => new(serviceId, contracServiceId, date, startTime, endTime);

    public void Update(long serviceId, long contracServiceId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
    {
        ServiceId = serviceId;
        ContractServiceId = contracServiceId;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
    }
    protected internal void SetState(IServiceTimeState state)
    => State = state;


    public static ICollection<ServiceTime> GenerateTimeSlots(Contract contract,
                    int interval,DateTime Date,
                    ICollection<WorkHoursException> workHoursException,
                    ICollection<Holiday> holidays)
    {
        HashSet<ServiceTime> serviceTimes = new();
        var leaves = GetLeaves(contract.Leaves.AsQueryable().AsNoTracking(), Date, Date.AddDays(interval));
        foreach (var contractService in contract.ContractServices)
        {
            var duration = contractService.Service!.Duration;
            TimeSpan Time = contractService.StartTime;
            while (DateOnly.FromDateTime(Date) <= contract.EndDate)
            {
                if (!holidays.Any(holiday => 
                holiday.Date == DateOnly.FromDateTime(Date)) && 
                Date.DayOfWeek.Equals(contractService.Day))
                {
                    while (Time < contractService.EndTime)
                    {
                        if (!workHoursException.Any(workHour => workHour.StartDate.Date == Date
                            && workHour.StartDate.TimeOfDay >= Time && workHour.EndDate.TimeOfDay <= Time.Add(duration))
                            || leaves.Any(leave => leave.StartDate.Date == Date
                            && leave.StartDate.TimeOfDay >= Time && leave.EndDate.TimeOfDay <= Time.Add(duration)))
                        {
                            serviceTimes.Add(Create(contractService.ServiceId,
                                       contract.Id, DateOnly.FromDateTime(Date),
                                       Time, Time.Add(duration)));
                        }
                        Time = Time.Add(duration);
                    }
                }
                Date = Date.AddDays(1);
            }
        }
        return serviceTimes;
    }
    private static IEnumerable<Leave> GetLeaves(IQueryable<Leave> leaves, DateTime StartDate, DateTime EndDate)
        => leaves.Where(_ => _.State == new ApprovedLeaveState()
                     && _.StartDate.Date >= StartDate
                     && _.EndDate.Date <= EndDate).AsEnumerable().ToList();

}