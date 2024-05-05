using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Services;
using Dr_Purple.Domain.Interfaces;

namespace Dr_Purple.Domain.Repositories;
public interface IServiceTimeRepository : IRepository<ServiceTime>
{
    //void GenerateTimeSlots(Contract contract, int interval, DateTime Date);
}