namespace Dr_Purple.Domain.Entities.Services.State;
public class LeavedServiceTimeState : IServiceTimeState
{
    public void Book(ServiceTime serviceTime)
    => throw new InvalidOperationException("Already Leaved");

    public void Cancel(ServiceTime serviceTime)
    => throw new InvalidOperationException("Already Leaved");

    public void Done(ServiceTime serviceTime)
    => throw new InvalidOperationException("Should Be Booked To Done It");

    public void Free(ServiceTime serviceTime)
    => throw new InvalidOperationException("Already Leaved");

    public void Leave(ServiceTime serviceTime)
    => throw new InvalidOperationException("Already Leaved");
    public void Update(ServiceTime serviceTime)
    => throw new InvalidOperationException("Already Leaved");
}