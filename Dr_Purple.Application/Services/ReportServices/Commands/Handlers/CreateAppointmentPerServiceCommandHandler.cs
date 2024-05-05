using Dr_Purple.Domain.Entities.Reports;
using Dr_Purple.Domain.Entities.Services.State;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.ReportServices.Commands.Handlers;

public class CreateAppointmentPerServiceCommandHandler : IRequestHandler<CreateAppointmentPerServiceCommand, Unit>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateAppointmentPerServiceCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<Unit> Handle(CreateAppointmentPerServiceCommand command, CancellationToken cancellationToken)
    {
        HashSet<AppointmentPerService> AppointmentPerServices = new();

        var services = await Task.FromResult(UnitOfWork.ServiceRepository.GetAll()
                                 .Include(_ => _.ServiceTimes
                                 .Where(_ => _.Date.Equals(command.Date)
                                  && _.State is BookedServiceTimeState))
                                 .AsSplitQuery());

        foreach (var service in services)
        {
            //AppointmentPerServices.Add(AppointmentPerService.Create(service.Id, command.Date, service.ServiceTimes.Count));
        }
        await UnitOfWork.AppointmentPerServiceRepository.AddRangeAsync(AppointmentPerServices!);
        await UnitOfWork.SaveChangesAsync();

        return await Task.FromResult(Unit.Value);
    }
}