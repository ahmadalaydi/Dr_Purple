namespace Dr_Purple.Domain.Entities.Contracts.LeaveStatus;
public interface ILeaveState
{
    public abstract void Approve(Leave leave);
    public abstract void DeApprove(Leave leave);
}