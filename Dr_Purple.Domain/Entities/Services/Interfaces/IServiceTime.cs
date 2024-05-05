using Dr_Purple.Domain.Interfaces;
namespace Dr_Purple.Domain.Entities.Services.Interfaces;
public interface IServiceTime : IEntity
{
    static ServiceTime Create(long serviceId, long contracServiceId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
        => Create(serviceId, contracServiceId, date, startTime, endTime);

    static void Update(long serviceId, long contracServiceId, DateOnly date, TimeSpan startTime, TimeSpan endTime)
        => Update(serviceId, contracServiceId, date, startTime, endTime);
}