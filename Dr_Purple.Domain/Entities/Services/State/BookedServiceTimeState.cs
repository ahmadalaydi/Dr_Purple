using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Payments;

namespace Dr_Purple.Domain.Entities.Services.State;
public class BookedServiceTimeState : IServiceTimeState
{
    public void Book(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Booked");

    public void Cancel(ServiceTime serviceTime)
        => serviceTime.SetState(new CanceledServiceTimeState());

    public void Done(ServiceTime serviceTime)
    {
        serviceTime.Appointment!.CreateAppointmentPayment(
            AppointmentPayment.CreateAppointmentPayment(
            serviceTime.Appointment.Id, serviceTime.Service!.SubDepartmentId));
            
        serviceTime.SetState(new BookedServiceTimeState());
    }

    public void Free(ServiceTime serviceTime)
        => throw new InvalidOperationException("Already Booked");

    public void Leave(ServiceTime serviceTime)
    => serviceTime.SetState(new LeavedServiceTimeState());

    public void Update(ServiceTime serviceTime) { }
}