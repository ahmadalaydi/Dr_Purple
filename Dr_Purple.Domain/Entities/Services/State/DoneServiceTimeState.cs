namespace Dr_Purple.Domain.Entities.Services.State;
public class DoneServiceTimeState : IServiceTimeState
{
    public void Book(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Done");

    public void Cancel(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Done");

    public void Done(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Done");

    public void Free(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Done");
    public void Leave(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Done");
    public void Update(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Done");
}