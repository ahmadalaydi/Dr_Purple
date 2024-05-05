using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;

namespace Dr_Purple.Infrastructure.Repositories.Base;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _dbContext;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IAdditionRepository> _additionRepository;
    private readonly Lazy<IAppointmentMaterialRepository> _appointmentMaterialRepository;
    private readonly Lazy<IAppointmentRepository> _appointmentRepository;
    private readonly Lazy<IAttendRepository> _attendRepository;
    private readonly Lazy<IContractRepository> _contractRepository;
    private readonly Lazy<IContractServiceRepository> _contractServiceRepository;
    private readonly Lazy<IDepartmentRepository> _departmentRepository;
    private readonly Lazy<ILeaveRepository> _leaveRepository;
    private readonly Lazy<IForSaleMaterialRepository> _forSaleMaterialRepository;
    private readonly Lazy<INotForSaleMaterialRepository> _notForSaleMaterialRepository;
    private readonly Lazy<ISalePaymentRepository> _salePaymentRepository;
    private readonly Lazy<IServiceRepository> _serviceRepository;
    private readonly Lazy<ILeaveBalanceRepository> _leaveBalanceRepository;
    private readonly Lazy<IServiceTimeRepository> _serviceTimeRepository;
    private readonly Lazy<IHolidayRepository> _holidayRepository;
    private readonly Lazy<IWorkHoursExceptionRepository> _workHoursExceptionRepository;
    private readonly Lazy<IJobTitleRepository> _jobTitleRepository;
    private readonly Lazy<IBlogRepository> _blogRepository;
    private readonly Lazy<ITagRepository> _tagRepository;
    private readonly Lazy<ISalePerMaterialRepository> _salePerMaterialRepository;
    private readonly Lazy<IAppointmentPerContractRepository> _appointmentPerContractRepository;
    private readonly Lazy<IAppointmentPerServiceRepository> _appointmentPerServiceRepository;
    private readonly Lazy<IAuditHistoryRepository> _auditHistoryRepository;
    private readonly Lazy<IAppointmentPaymentRepository> _appointmentPaymentRepository;
    private readonly Lazy<ISalePaymentItemRepository> _salePaymentMaterialRepository;
    private readonly Lazy<ISaleSubDepartmentRepository> _saleSubDepartmentRepository;
    private readonly Lazy<INotForSaleOrderPaymentRepository> _notForSaleOrderPaymentRepository;
    private readonly Lazy<IAdministrativeSubDepartmentRepository> _administrativeSubDepartmentRepository;
    private readonly Lazy<IServiceProviderSubDepartmentRepository> _serviceProviderSubDepartmentRepository;
    private readonly Lazy<IForSaleOrderItemRepository> _forSaleOrderItemRepository;
    private readonly Lazy<IForSaleOrderPaymentRepository> _forSaleOrderPaymentRepository;
    private readonly Lazy<INotForSaleOrderItemRepository> _notForSaleOrderItemRepository;


    public UnitOfWork(AppDbContext dbContext,
        Lazy<IUserRepository> userRepository,
        Lazy<IAdditionRepository> additionRepository,
        Lazy<IAppointmentMaterialRepository> appointmentMaterialRepository,
        Lazy<IAppointmentRepository> appointmentRepository,
        Lazy<IAttendRepository> attendRepository,
        Lazy<IContractRepository> contractRepository,
        Lazy<IContractServiceRepository> contractServiceRepository,
        Lazy<IDepartmentRepository> departmentRepository,
        Lazy<ILeaveRepository> leaveRepository,
        Lazy<IForSaleMaterialRepository> forSaleMaterialRepository,
        Lazy<INotForSaleMaterialRepository> notForSaleMaterialRepository,
        Lazy<ISalePaymentRepository> salePaymentRepository,
        Lazy<IServiceRepository> serviceRepository,
        Lazy<ILeaveBalanceRepository> leaveBalanceRepository,
        Lazy<IServiceTimeRepository> serviceTimeRepository,
        Lazy<IHolidayRepository> holidayRepository,
        Lazy<IWorkHoursExceptionRepository> workHoursExceptionRepository,
        Lazy<IJobTitleRepository> jobTitleRepository,
        Lazy<IBlogRepository> blogRepository,
        Lazy<ITagRepository> tagRepository,
        Lazy<ISalePerMaterialRepository> salePerMaterialRepository,
        Lazy<IAppointmentPerContractRepository> appointmentPerContractRepository,
        Lazy<IAppointmentPerServiceRepository> appointmentPerServiceRepository,
        Lazy<IAuditHistoryRepository> auditHistoryRepository,
        Lazy<ISalePaymentItemRepository> salePaymentMaterialRepository,
        Lazy<INotForSaleOrderPaymentRepository> notForSaleOrderPaymentRepository,
        Lazy<IAppointmentPaymentRepository> appointmentPaymentRepository,
        Lazy<ISaleSubDepartmentRepository> saleSubDepartmentRepository,
        Lazy<IAdministrativeSubDepartmentRepository> administrativeSubDepartmentRepository,
        Lazy<IServiceProviderSubDepartmentRepository> serviceProviderSubDepartmentRepository,
        Lazy<IForSaleOrderItemRepository> forSaleOrderItemRepository,
        Lazy<IForSaleOrderPaymentRepository> forSaleOrderPaymentRepository,
        Lazy<INotForSaleOrderItemRepository> notForSaleOrderItemRepository)
    {
        _dbContext = dbContext;
        _userRepository = userRepository;
        _additionRepository = additionRepository;
        _appointmentMaterialRepository = appointmentMaterialRepository;
        _appointmentRepository = appointmentRepository;
        _attendRepository = attendRepository;
        _contractRepository = contractRepository;
        _contractServiceRepository = contractServiceRepository;
        _departmentRepository = departmentRepository;
        _leaveRepository = leaveRepository;
        _forSaleMaterialRepository = forSaleMaterialRepository;
        _notForSaleMaterialRepository = notForSaleMaterialRepository;
        _salePaymentRepository = salePaymentRepository;
        _serviceRepository = serviceRepository;
        _leaveBalanceRepository = leaveBalanceRepository;
        _serviceTimeRepository = serviceTimeRepository;
        _holidayRepository = holidayRepository;
        _workHoursExceptionRepository = workHoursExceptionRepository;
        _jobTitleRepository = jobTitleRepository;
        _blogRepository = blogRepository;
        _tagRepository = tagRepository;
        _salePerMaterialRepository = salePerMaterialRepository;
        _appointmentPerContractRepository = appointmentPerContractRepository;
        _appointmentPerServiceRepository = appointmentPerServiceRepository;
        _auditHistoryRepository = auditHistoryRepository;
        _salePaymentMaterialRepository = salePaymentMaterialRepository;
        _appointmentPaymentRepository = appointmentPaymentRepository;
        _saleSubDepartmentRepository = saleSubDepartmentRepository;
        _administrativeSubDepartmentRepository = administrativeSubDepartmentRepository;
        _serviceProviderSubDepartmentRepository = serviceProviderSubDepartmentRepository;
        _forSaleOrderItemRepository = forSaleOrderItemRepository;
        _forSaleOrderPaymentRepository = forSaleOrderPaymentRepository;
        _notForSaleOrderPaymentRepository = notForSaleOrderPaymentRepository;
        _notForSaleOrderItemRepository = notForSaleOrderItemRepository;
    }

    public IUserRepository UserRepository
        => _userRepository.Value;
    public IAdditionRepository AdditionRepository
        => _additionRepository.Value;
    public IAppointmentMaterialRepository AppointmentMaterialRepository
        => _appointmentMaterialRepository.Value;
    public IAppointmentRepository AppointmentRepository
        => _appointmentRepository.Value;
    public IAttendRepository AttendRepository
        => _attendRepository.Value;
    public IContractRepository ContractRepository
        => _contractRepository.Value;
    public IContractServiceRepository ContractServiceRepository
        => _contractServiceRepository.Value;
    public IDepartmentRepository DepartmentRepository
        => _departmentRepository.Value;
    public ILeaveRepository LeaveRepository
        => _leaveRepository.Value;
    public IForSaleMaterialRepository ForSaleMaterialRepository
        => _forSaleMaterialRepository.Value;
    public INotForSaleMaterialRepository NotForSaleMaterialRepository
        => _notForSaleMaterialRepository.Value;
    public ISalePaymentRepository SalePaymentRepository
        => _salePaymentRepository.Value;
    public IServiceRepository ServiceRepository
        => _serviceRepository.Value;
    public ILeaveBalanceRepository LeaveBalanceRepository
        => _leaveBalanceRepository.Value;
    public IServiceTimeRepository ServiceTimeRepository
        => _serviceTimeRepository.Value;
    public IHolidayRepository HolidayRepository
        => _holidayRepository.Value;
    public IWorkHoursExceptionRepository WorkHoursExceptionRepository
        => _workHoursExceptionRepository.Value;
    public IJobTitleRepository JobTitleRepository
        => _jobTitleRepository.Value;
    public IBlogRepository BlogRepository
        => _blogRepository.Value;
    public ITagRepository TagRepository
        => _tagRepository.Value;
    public ISalePerMaterialRepository SalePerMaterialRepository
        => _salePerMaterialRepository.Value;
    public IAppointmentPerContractRepository AppointmentPerContractRepository
        => _appointmentPerContractRepository.Value;
    public IAppointmentPerServiceRepository AppointmentPerServiceRepository
        => _appointmentPerServiceRepository.Value;
    public IAuditHistoryRepository AuditHistoryRepository
        => _auditHistoryRepository.Value;
    public ISalePaymentItemRepository SalePaymentItemRepository
    => _salePaymentMaterialRepository.Value;
    public IAppointmentPaymentRepository AppointmentPaymentRepository
    => _appointmentPaymentRepository.Value;
    public ISaleSubDepartmentRepository SaleSubDepartmentRepository
    => _saleSubDepartmentRepository.Value;
    public IAdministrativeSubDepartmentRepository AdministrativeSubDepartmentRepository
        => _administrativeSubDepartmentRepository.Value;
    public IServiceProviderSubDepartmentRepository ServiceProviderSubDepartmentRepository
        => _serviceProviderSubDepartmentRepository.Value;
    public IForSaleOrderItemRepository ForSaleOrderItemRepository
        => _forSaleOrderItemRepository.Value;
    public IForSaleOrderPaymentRepository ForSaleOrderPaymentRepository
        => _forSaleOrderPaymentRepository.Value;
    public INotForSaleOrderPaymentRepository NotForSaleOrderPaymentRepository
        => _notForSaleOrderPaymentRepository.Value;
    public INotForSaleOrderItemRepository NotForSaleOrderItemRepository
        => _notForSaleOrderItemRepository.Value;
    public async Task SaveChangesAsync()
        => await _dbContext.SaveChangesAsync();
}