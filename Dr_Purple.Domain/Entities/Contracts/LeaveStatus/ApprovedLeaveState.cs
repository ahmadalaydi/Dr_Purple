namespace Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
public class ApprovedLeaveState : ILeaveState
{
    public void Approve(Leave leave)
    => throw new InvalidOperationException("Already Approved");

    public void DeApprove(Leave leave)
    => leave.SetState(new NotApprovedLeaveState());
}