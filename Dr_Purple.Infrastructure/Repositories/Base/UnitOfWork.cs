using Dr_Purple.Domain.Interfaces;
using Dr_Purple.Domain.Repositories;
using Dr_Purple.Infrastructure.Data;

namespace Dr_Purple.Infrastructure.Repositories.Base;
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext? _dbContext;
    public UnitOfWork(AppDbContext? dbContext)
       => _dbContext = dbContext;

    public IRepository<T> Repository<T>() where T :class, IEntity
    => new BaseRepository<T>(_dbContext);

    public IUserRepository UserRepository
        => new UserRepository(_dbContext);

    public IAdditionRepository AdditionRepository
        => new AdditionRepository(_dbContext);

    public IAppointmentMaterialRepository AppointmentMaterialRepository
        => new AppointmentMaterialRepository(_dbContext);
    public IAppointmentRepository AppointmentRepository
        => new AppointmentRepository(_dbContext);
    public IAttendRepository AttendRepository
        => new AttendRepository(_dbContext);
    public IContractRepository ContractRepository
        => new ContractRepository(_dbContext);
    public IContractServiceRepository ContractServiceRepository
        => new ContractServiceRepository(_dbContext);
    public IDepartmentRepository DepartmentRepository
        => new DepartmentRepository(_dbContext);
    public ILeaveRepository LeaveRepository
        => new LeaveRepository(_dbContext);
    public IMaterialCostPriceRepository MaterialCostPriceRepository
        => new MaterialCostPriceRepository(_dbContext);
    public IMaterialRepository MaterialRepository
        => new MaterialRepository(_dbContext);
    public IMaterialSellPriceRepository MaterialSellPriceRepository
        => new MaterialSellPriceRepository(_dbContext);
    public IOfferRepository OfferRepository
        => new OfferRepository(_dbContext);
    public IOrderItemRepository OrderItemRepository
        => new OrderItemRepository(_dbContext);
    public IOrderRepository OrderRepository
        => new OrderRepository(_dbContext);
    public IPaymentMaterialRepository PaymentMaterialRepository
        => new PaymentMaterialRepository(_dbContext);
    public IPaymentOfferRepository PaymentOfferRepository
        => new PaymentOfferRepository(_dbContext);
    public IPaymentRepository PaymentRepository
        => new PaymentRepository(_dbContext);
    public IServiceRepository ServiceRepository
        => new ServiceRepository(_dbContext);
    public ISubDepartmentMaterialRepository SubDepartmentMaterialRepository
        => new SubDepartmentMaterialRepository(_dbContext);
    public ISubDepartmentRepository SubDepartmentRepository
        => new SubDepartmentRepository(_dbContext);
    public IUnitRepository UnitRepository
        => new UnitRepository(_dbContext);
    public IContractTimeRepository ContractTimeRepository
        => new ContractTimeRepository(_dbContext);
    public ILeaveBalanceRepository LeaveBalanceRepository
        => new LeaveBalanceRepository(_dbContext);
    public IOfferDateRepository OfferDateRepository
        => new OfferDateRepository(_dbContext);
    public IServiceCostPriceRepository ServiceCostPriceRepository
        => new ServiceCostPriceRepository(_dbContext);
    public IServiceTimeRepository ServiceTimeRepository
        => new ServiceTimeRepository(_dbContext);
    public IAddressRepository AddressRepository
        => new AddressRepository(_dbContext);
    public ICityRepository CityRepository
        => new CityRepository(_dbContext);
    public IRegionRepository RegionRepository
        => new RegionRepository(_dbContext);

    public Task<int> SaveChangesAsync()
        => _dbContext!.SaveChangesAsync();
}