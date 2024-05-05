using Dr_Purple.Domain.Entities.Services.State;

namespace Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
public class NotApprovedLeaveState : ILeaveState
{
    public void Approve(Leave leave)
    {
        //foreach(var service in leave.Contract!.ContractServices) 
        //{
        //    service.ServiceTimes.FirstOrDefault(_=>
        //    _.Date >= DateOnly.FromDateTime(leave.StartDate)
        //    && _.Date <= DateOnly.FromDateTime(leave.EndDate)
        //    && _.StartTime > leave.StartDate.TimeOfDay
        //    && _.EndTime > leave.EndDate.TimeOfDay
        //    && _.State == new BookedServiceTimeState())!
        //    .SetState(new CanceledServiceTimeState());
        //}
        leave.SetState(new ApprovedLeaveState());
    }

    public void DeApprove(Leave leave)
    => throw new InvalidOperationException("Already Approved");
}