namespace Dr_Purple.Domain.Entities.Services.State;
public interface IServiceTimeState
{
    public abstract void Book(ServiceTime serviceTime);
    public abstract void Cancel(ServiceTime serviceTime);
    public abstract void Free(ServiceTime serviceTime);
    public abstract void Done(ServiceTime serviceTime);
    public abstract void Leave(ServiceTime serviceTime);
    public abstract void Update(ServiceTime serviceTime);
}