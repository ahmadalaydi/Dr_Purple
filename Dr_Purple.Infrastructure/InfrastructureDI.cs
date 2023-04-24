using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;
using Dr_Purple.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dr_Purple.Infrastructure;
public static class InfrastructureDI
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configration)
    {
        return services
            .AddTransient(_ => AddData(configration))
            .AddScoped(typeof(IAdditionRepository), typeof(AdditionRepository))
            .AddScoped(typeof(IAppointmentMaterialRepository), typeof(AppointmentMaterialRepository))
            .AddScoped(typeof(IAppointmentRepository), typeof(AppointmentRepository))
            .AddScoped(typeof(IAttendRepository), typeof(AttendRepository))
            .AddScoped(typeof(IContractRepository), typeof(ContractRepository))
            .AddScoped(typeof(IContractServiceRepository), typeof(ContractServiceRepository))
            .AddScoped(typeof(IDepartmentRepository), typeof(DepartmentRepository))
            .AddScoped(typeof(ILeaveRepository), typeof(LeaveRepository))
            .AddScoped(typeof(IMaterialCostPriceRepository), typeof(MaterialCostPriceRepository))
            .AddScoped(typeof(IMaterialRepository), typeof(MaterialRepository))
            .AddScoped(typeof(IMaterialSellPriceRepository), typeof(MaterialSellPriceRepository))
            .AddScoped(typeof(IOfferRepository), typeof(OfferRepository))
            .AddScoped(typeof(IOrderItemRepository), typeof(OrderItemRepository))
            .AddScoped(typeof(IOrderRepository), typeof(OrderRepository))
            .AddScoped(typeof(IPaymentMaterialRepository), typeof(PaymentMaterialRepository))
            .AddScoped(typeof(IPaymentOfferRepository), typeof(PaymentOfferRepository))
            .AddScoped(typeof(IPaymentRepository), typeof(PaymentRepository))
            .AddScoped(typeof(IServiceRepository), typeof(ServiceRepository))
            .AddScoped(typeof(ISubDepartmentMaterialRepository), typeof(SubDepartmentMaterialRepository))
            .AddScoped(typeof(ISubDepartmentRepository), typeof(SubDepartmentRepository))
            .AddScoped(typeof(IUnitRepository), typeof(UnitRepository))
            .AddScoped(typeof(IWareHouseRepository), typeof(WareHouseRepository))
            .AddScoped(typeof(IWareHouseMaterialRepository), typeof(WareHouseMaterialRepository));
    }


    private static AppDbContext AddData(IConfiguration configration)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseSqlServer(configration.GetConnectionString("DefaultConnection"));
        return new AppDbContext(optionsBuilder.Options);
    }
}
