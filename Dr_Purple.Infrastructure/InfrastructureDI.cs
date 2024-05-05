using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data.DbContexts;
using Dr_Purple.Infrastructure.Repositories;
using Dr_Purple.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Infrastructure;
public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configration)
    {
        return services
            .AddData(configration)
            .AddScoped(typeof(IRepository<>), typeof(BaseRepository<>))
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IAdditionRepository, AdditionRepository>()
            .AddScoped<IAppointmentMaterialRepository, AppointmentMaterialRepository>()
            .AddScoped<IAppointmentRepository, AppointmentRepository>()
            .AddScoped<IAttendRepository, AttendRepository>()
            .AddScoped<IContractRepository, ContractRepository>()
            .AddScoped<IContractServiceRepository, ContractServiceRepository>()
            .AddScoped<IDepartmentRepository, DepartmentRepository>()
            .AddScoped<ILeaveRepository, LeaveRepository>()
            .AddScoped<IForSaleMaterialRepository, ForSaleMaterialRepository>()
            .AddScoped<INotForSaleMaterialRepository, NotForSaleMaterialRepository>()
            .AddScoped<ISalePaymentRepository, SalePaymentRepository>()
            .AddScoped<IServiceRepository, ServiceRepository>()
            .AddScoped<IAppointmentPerContractRepository, AppointmentPerContractRepository>()
            .AddScoped<IAppointmentPerServiceRepository, AppointmentPerServiceRepository>()
            .AddScoped<IAuditHistoryRepository, AuditHistoryRepository>()
            .AddScoped<IBlogRepository, BlogRepository>()
            .AddScoped<IHolidayRepository, HolidayRepository>()
            .AddScoped<IJobTitleRepository, JobTitleRepository>()
            .AddScoped<ILeaveBalanceRepository, LeaveBalanceRepository>()
            .AddScoped<ISalePerMaterialRepository, SalePerMaterialRepository>()
            .AddScoped<IServiceTimeRepository, ServiceTimeRepository>()
            .AddScoped<ITagRepository, TagRepository>()
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IWorkHoursExceptionRepository, WorkHoursExceptionRepository>()
            .AddScoped<ISalePaymentItemRepository, SalePaymentItemRepository>()
            .AddScoped<INotForSaleOrderPaymentRepository, NotForSaleOrderPaymentRepository>()
            .AddScoped<IAppointmentPaymentRepository, AppointmentPaymentRepository>()
            .AddScoped<ISaleSubDepartmentRepository, SaleSubDepartmentRepository>()
            .AddScoped<IAdministrativeSubDepartmentRepository, AdministrativeSubDepartmentRepository>()
            .AddScoped<IServiceProviderSubDepartmentRepository, ServiceProviderSubDepartmentRepository>()
            .AddScoped<IForSaleOrderItemRepository, ForSaleOrderItemRepository>()
            .AddScoped<IForSaleOrderPaymentRepository, ForSaleOrderPaymentRepository>()
            .AddScoped<INotForSaleOrderItemRepository, NotForSaleOrderItemRepository>()

            .AddScoped(x => new Lazy<IServiceProviderSubDepartmentRepository>(() => x.GetRequiredService<IServiceProviderSubDepartmentRepository>()))
            .AddScoped(x => new Lazy<IAdministrativeSubDepartmentRepository>(() => x.GetRequiredService<IAdministrativeSubDepartmentRepository>()))
            .AddScoped(x => new Lazy<ISaleSubDepartmentRepository>(() => x.GetRequiredService<ISaleSubDepartmentRepository>()))
            .AddScoped(x => new Lazy<IAdditionRepository>(() => x.GetRequiredService<IAdditionRepository>()))
            .AddScoped(x => new Lazy<IAppointmentMaterialRepository>(() => x.GetRequiredService<IAppointmentMaterialRepository>()))
            .AddScoped(x => new Lazy<IAppointmentRepository>(() => x.GetRequiredService<IAppointmentRepository>()))
            .AddScoped(x => new Lazy<IAttendRepository>(() => x.GetRequiredService<IAttendRepository>()))
            .AddScoped(x => new Lazy<IContractRepository>(() => x.GetRequiredService<IContractRepository>()))
            .AddScoped(x => new Lazy<IContractServiceRepository>(() => x.GetRequiredService<IContractServiceRepository>()))
            .AddScoped(x => new Lazy<IDepartmentRepository>(() => x.GetRequiredService<IDepartmentRepository>()))
            .AddScoped(x => new Lazy<ILeaveRepository>(() => x.GetRequiredService<ILeaveRepository>()))
            .AddScoped(x => new Lazy<IForSaleMaterialRepository>(() => x.GetRequiredService<IForSaleMaterialRepository>()))
            .AddScoped(x => new Lazy<INotForSaleMaterialRepository>(() => x.GetRequiredService<INotForSaleMaterialRepository>()))
            .AddScoped(x => new Lazy<ISalePaymentRepository>(() => x.GetRequiredService<ISalePaymentRepository>()))
            .AddScoped(x => new Lazy<IServiceRepository>(() => x.GetRequiredService<IServiceRepository>()))
            .AddScoped(x => new Lazy<IAppointmentPerContractRepository>(() => x.GetRequiredService<IAppointmentPerContractRepository>()))
            .AddScoped(x => new Lazy<IAppointmentPerServiceRepository>(() => x.GetRequiredService<IAppointmentPerServiceRepository>()))
            .AddScoped(x => new Lazy<IAuditHistoryRepository>(() => x.GetRequiredService<IAuditHistoryRepository>()))
            .AddScoped(x => new Lazy<IBlogRepository>(() => x.GetRequiredService<IBlogRepository>()))
            .AddScoped(x => new Lazy<IHolidayRepository>(() => x.GetRequiredService<IHolidayRepository>()))
            .AddScoped(x => new Lazy<IJobTitleRepository>(() => x.GetRequiredService<IJobTitleRepository>()))
            .AddScoped(x => new Lazy<ILeaveBalanceRepository>(() => x.GetRequiredService<ILeaveBalanceRepository>()))
            .AddScoped(x => new Lazy<ISalePerMaterialRepository>(() => x.GetRequiredService<ISalePerMaterialRepository>()))
            .AddScoped(x => new Lazy<IServiceTimeRepository>(() => x.GetRequiredService<IServiceTimeRepository>()))
            .AddScoped(x => new Lazy<ITagRepository>(() => x.GetRequiredService<ITagRepository>()))
            .AddScoped(x => new Lazy<IUserRepository>(() => x.GetRequiredService<IUserRepository>()))
            .AddScoped(x => new Lazy<IWorkHoursExceptionRepository>(() => x.GetRequiredService<IWorkHoursExceptionRepository>()))
            .AddScoped(x => new Lazy<ISalePaymentItemRepository>(() => x.GetRequiredService<ISalePaymentItemRepository>()))
            .AddScoped(x => new Lazy<INotForSaleOrderPaymentRepository>(() => x.GetRequiredService<INotForSaleOrderPaymentRepository>()))
            .AddScoped(x => new Lazy<IAppointmentPaymentRepository>(() => x.GetRequiredService<IAppointmentPaymentRepository>()))
            .AddScoped(x => new Lazy<IForSaleOrderItemRepository>(() => x.GetRequiredService<IForSaleOrderItemRepository>()))
            .AddScoped(x => new Lazy<IForSaleOrderPaymentRepository>(() => x.GetRequiredService<IForSaleOrderPaymentRepository>()))
            .AddScoped(x => new Lazy<INotForSaleOrderItemRepository>(() => x.GetRequiredService<INotForSaleOrderItemRepository>()));
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configration)
        => services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configration.GetConnectionString("DefaultConnection")));
}