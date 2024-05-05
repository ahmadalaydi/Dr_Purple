using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Entities.Payments.Interfaces;
public interface IPayment : IEntity
{
    static SalePayment Create()
        => Create();

    static AppointmentPayment CreateAppointmentPayment(long appointmentId)
        => CreateAppointmentPayment(appointmentId);

    static NotForSaleOrderPayment CreateWareHousePayment(long wareHouseId)
        => CreateWareHousePayment(wareHouseId);

    static void Approve() => Approve();
}