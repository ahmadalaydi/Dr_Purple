namespace Dr_Purple.Domain.Entities.Services.State;
public class FreeServiceTimeState : IServiceTimeState
{
    public void Book(ServiceTime serviceTime)
        => serviceTime.SetState(new BookedServiceTimeState());

    public void Cancel(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Canceled");

    public void Done(ServiceTime serviceTime)
        => throw new InvalidOperationException("Should Be Booked To Done It");

    public void Free(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Free");
    public void Leave(ServiceTime serviceTime)
    => serviceTime.SetState(new LeavedServiceTimeState());
    public void Update(ServiceTime serviceTime)
     => throw new InvalidOperationException("Should Be Booked");
}