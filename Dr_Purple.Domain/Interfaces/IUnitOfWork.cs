using Dr_Purple.Domain.Repositories;

namespace Dr_Purple.Domain.Interfaces;
public interface IUnitOfWork
{
    Task SaveChangesAsync();
    IUserRepository UserRepository { get; }
    IAdditionRepository AdditionRepository { get; }
    IAppointmentMaterialRepository AppointmentMaterialRepository { get; }
    IAppointmentRepository AppointmentRepository { get; }
    IAttendRepository AttendRepository { get; }
    IContractRepository ContractRepository { get; }
    IContractServiceRepository ContractServiceRepository { get; }
    IDepartmentRepository DepartmentRepository { get; }
    ILeaveRepository LeaveRepository { get; }
    IForSaleMaterialRepository ForSaleMaterialRepository { get; }
    INotForSaleMaterialRepository NotForSaleMaterialRepository { get; }
    ISalePaymentRepository SalePaymentRepository { get; }
    IServiceRepository ServiceRepository { get; }
    ISaleSubDepartmentRepository SaleSubDepartmentRepository { get; }
    IAdministrativeSubDepartmentRepository AdministrativeSubDepartmentRepository { get; }
    IServiceProviderSubDepartmentRepository ServiceProviderSubDepartmentRepository { get; }
    ILeaveBalanceRepository LeaveBalanceRepository { get; }
    IServiceTimeRepository ServiceTimeRepository { get; }
    IHolidayRepository HolidayRepository { get; }
    IWorkHoursExceptionRepository WorkHoursExceptionRepository { get; }
    IJobTitleRepository JobTitleRepository { get; }
    IBlogRepository BlogRepository { get; }
    ITagRepository TagRepository { get; }
    IAuditHistoryRepository AuditHistoryRepository { get; }
    IAppointmentPerContractRepository AppointmentPerContractRepository { get; }
    IAppointmentPerServiceRepository AppointmentPerServiceRepository { get; }
    ISalePerMaterialRepository SalePerMaterialRepository { get; }
    ISalePaymentItemRepository SalePaymentItemRepository { get; }
    INotForSaleOrderPaymentRepository NotForSaleOrderPaymentRepository { get; }
    IAppointmentPaymentRepository AppointmentPaymentRepository { get; }
    IForSaleOrderPaymentRepository ForSaleOrderPaymentRepository { get; }
    INotForSaleOrderItemRepository NotForSaleOrderItemRepository { get; }
    IForSaleOrderItemRepository ForSaleOrderItemRepository { get; }
}