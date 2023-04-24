using Dr_Purple.Domain.Entities.Additions;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Attends;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Leaves;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Entities.Offers;
using Dr_Purple.Domain.Entities.Orders;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Entities.WareHouses;
using Dr_Purple.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Infrastructure.Data;
public class AppDbContext : DbContext
{
    public virtual DbSet<User>? Users { get; set; }
    public virtual DbSet<Addition>? Additions { get; set; }
    public virtual DbSet<Appointment>? Appointments { get; set; }
    public virtual DbSet<AppointmentMaterial>? AppointmentMaterials { get; set; }
    public virtual DbSet<AppointmentPayment>? AppointmentPayments { get; set; }
    public virtual DbSet<AppointmentServiceTime>? AppointmentServiceTimes { get; set; }
    public virtual DbSet<Attend>? Attends { get; set; }
    public virtual DbSet<Contract>? Contracts { get; set; }
    public virtual DbSet<ContractService>? ContractServices { get; set; }
    public virtual DbSet<ContractTime>? ContractTimes { get; set; }
    public virtual DbSet<Department>? Departments { get; set; }
    public virtual DbSet<SubDepartment>? SubDepartments { get; set; }
    public virtual DbSet<SubDepartmentMaterial>? SubDepartmentMaterials { get; set; }
    public virtual DbSet<Leave>? Leaves { get; set; }
    public virtual DbSet<LeaveBalance>? LeaveBalances { get; set; }
    public virtual DbSet<Material>? Materials { get; set; }
    public virtual DbSet<MaterialCostPrice>? MaterialCostPrices { get; set; }
    public virtual DbSet<MaterialSellPrice>? MaterialSellPrices { get; set; }
    public virtual DbSet<Unit>? Units { get; set; }
    public virtual DbSet<Offer>? Offers { get; set; }
    public virtual DbSet<OfferDate>? OfferDates { get; set; }
    public virtual DbSet<Order>? Orders { get; set; }
    public virtual DbSet<OrderItem>? OrderItems { get; set; }
    public virtual DbSet<Payment>? Payments { get; set; }
    public virtual DbSet<PaymentMaterial>? PaymentMaterials { get; set; }
    public virtual DbSet<PaymentOffer>? PaymentOffers { get; set; }
    public virtual DbSet<Service>? Services { get; set; }
    public virtual DbSet<ServiceCostPrice>? ServiceCostPrices { get; set; }
    public virtual DbSet<ServiceTime>? ServiceTimes { get; set; }
    public virtual DbSet<Address>? Address { get; set; }
    public virtual DbSet<City>? Citys { get; set; }
    public virtual DbSet<Region>? Regions { get; set; }
    public virtual DbSet<WareHouse>? WareHouses { get; set; }
    public virtual DbSet<WareHouseMaterial>? WareHouseMaterials { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplyConfigurations(modelBuilder);
    }
    protected static ModelBuilder ApplyConfigurations(ModelBuilder modelBuilder)
        => modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AdditionConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AddressConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentServiceTimeConfig).Assembly)
        .ApplyConfigurationsFromAssembly(typeof(AttendConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(CityConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ContractConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ContractServiceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ContractTimeConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(DepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(LeaveBalanceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(LeaveConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(MaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(MaterialCostPriceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(MaterialSellPriceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(OfferConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(OfferDateConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(OrderConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(OrderItemConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(PaymentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(PaymentMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(PaymentOfferConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(RegionConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceCostPriceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceTimeConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SubDepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SubDepartmentMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(UnitConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(WareHouseConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(WareHouseMaterialConfig).Assembly);
}
