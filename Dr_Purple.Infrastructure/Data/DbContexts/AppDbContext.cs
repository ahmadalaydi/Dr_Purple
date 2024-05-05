using Dr_Purple.Domain.Attributes;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Auditing;
using Dr_Purple.Domain.Entities.Base;
using Dr_Purple.Domain.Entities.Blogs;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Departments;
using Dr_Purple.Domain.Entities.Departments.Base;
using Dr_Purple.Domain.Entities.Materials;
using Dr_Purple.Domain.Entities.Payments;
using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Entities.Users;
using Dr_Purple.Domain.Entities.Works;
using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Infrastructure.Auditing;
using Dr_Purple.Infrastructure.Auditing.Extensions;
using Dr_Purple.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Dr_Purple.Infrastructure.Data.DbContexts;
public class AppDbContext : DbContext
{
    private readonly IAuthenticatedUserService _authenticatedUser;
    public virtual DbSet<AuditHistory>? AuditHistory { get; set; }
    public virtual DbSet<Blog> Blogs { get; set; }
    public virtual DbSet<Tag>? Tags { get; set; }
    public virtual DbSet<BlogTag>? BlogTags { get; set; }
    public virtual DbSet<User>? Users { get; set; }
    public virtual DbSet<Addition>? Additions { get; set; }
    public virtual DbSet<Appointment>? Appointments { get; set; }
    public virtual DbSet<AppointmentMaterial>? AppointmentMaterials { get; set; }
    public virtual DbSet<AppointmentPayment>? AppointmentPayments { get; set; }
    public virtual DbSet<Attend>? Attends { get; set; }
    public virtual DbSet<Contract>? Contracts { get; set; }
    public virtual DbSet<ContractService>? ContractServices { get; set; }
    public virtual DbSet<Department>? Departments { get; set; }
    public virtual DbSet<SaleSubDepartment>? SaleSubDepartments { get; set; }
    public virtual DbSet<AdministrativeSubDepartment>? AdministrativeSubDepartments { get; set; }
    public virtual DbSet<ServiceProviderSubDepartment>? ServiceProviderSubDepartments { get; set; }
    public virtual DbSet<SaleSubDepartmentMaterial>? SaleSubDepartmentMaterials { get; set; }
    public virtual DbSet<ServiceProviderSubDepartmentMaterial>? ServiceProviderSubDepartmentMaterials { get; set; }
    public virtual DbSet<Leave>? Leaves { get; set; }
    public virtual DbSet<LeaveBalance>? LeaveBalances { get; set; }
    public virtual DbSet<ForSaleMaterial>? ForSaleMaterials { get; set; }
    public virtual DbSet<NotForSaleMaterial>? NotForSaleMaterials { get; set; }
    public virtual DbSet<ForSaleOrderPayment>? ForSaleOrderPayments { get; set; }
    public virtual DbSet<NotForSaleOrderPayment>? NotForSaleOrderPayments { get; set; }
    public virtual DbSet<NotForSaleOrderItem>? NotForSaleOrderItems { get; set; }
    public virtual DbSet<ForSaleOrderItem>? ForSaleOrderItems { get; set; }
    public virtual DbSet<SalePayment>? SalePayments { get; set; }
    public virtual DbSet<SalePaymentItem>? SalePaymentItems { get; set; }
    public virtual DbSet<Service>? Services { get; set; }

    [NotAuditable]
    public virtual DbSet<ServiceTime>? ServiceTimes { get; set; }
    public virtual DbSet<Holiday>? Holidays { get; set; }
    public virtual DbSet<WorkHoursException>? WorkHoursExceptions { get; set; }
    public virtual DbSet<SalePerMaterial>? SellsPerMaterial { get; set; }
    public virtual DbSet<AppointmentPerContract>? AppointmentsPerContract { get; set; }
    public virtual DbSet<AppointmentPerService>? AppointmentsPerService { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options, IAuthenticatedUserService authenticatedUser) : base(options)
        => _authenticatedUser = authenticatedUser;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        ApplyConfigurations(modelBuilder);
        modelBuilder.EnableAuditHistory();
    }
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {

        foreach (var e in ChangeTracker.Entries()
                 .Where(e => !AuditUtilities.IsAuditDisabled
                 (e.Entity.GetType())).ToList())
        {
            DbContextUpdateOperations.UpdateDates(ChangeTracker.Entries<AuditableEntity>(), _authenticatedUser.UserId!);
            this.EnsureAuditHistory(_authenticatedUser.UserId!);
        }
        return base.SaveChangesAsync(true, cancellationToken);
    }


    protected static ModelBuilder ApplyConfigurations(ModelBuilder modelBuilder)
             => modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AdditionConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AdministrativeSubDepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentPaymentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentPerContractConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AppointmentPerServiceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(AttendConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ContractConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ContractServiceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(DepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ForSaleMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ForSaleOrderPaymentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(HolidayConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(LeaveBalanceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(LeaveConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(MaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(NotForSaleMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(NotForSaleOrderPaymentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SalePaymentItemConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SalePaymentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(PaymentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SalePerMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SaleSubDepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SaleSubDepartmentMaterial).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceProviderSubDepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceProviderSubDepartmentMaterialConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(ServiceTimeConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(SubDepartmentConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(JobTitleConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(BlogConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(TagConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(BlogTagConfig).Assembly)
                            .ApplyConfigurationsFromAssembly(typeof(WorkHoursExceptionConfig).Assembly);
}