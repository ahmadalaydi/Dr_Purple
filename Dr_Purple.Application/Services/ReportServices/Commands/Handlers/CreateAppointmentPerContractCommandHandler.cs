using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ReportServices.Commands.Handlers;

public class CreateAppointmentPerContractCommandHandler : IRequestHandler<CreateAppointmentPerContractCommand, Unit>
{
    private readonly IUnitOfWork UnitOfWork;
    public CreateAppointmentPerContractCommandHandler(IUnitOfWork unitOfWork)
        => UnitOfWork = unitOfWork;
    public async Task<Unit> Handle(CreateAppointmentPerContractCommand command, CancellationToken cancellationToken)
    {
        //HashSet<AppointmentPerContract> AppointmentPerContracts = new();

        //var ActiveContracts = await Task.FromResult(UnitOfWork.ContractRepository
        //    .GetBy(_ => _.State is ActiveContractState));
        //    .Include(_ => _.ContractServices
        //    .Where(_ => _.ServiceTimes. is BookedServiceTimeState
        //               && _.Date.Equals(command.Date))).AsSplitQuery());
        //var contract = await UnitOfWork.ContractRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));

        //foreach (var service in contract.ContractServices)
        //{
        //    service.ServiceTimes
        //    foreach (var serviceTime in service.ServiceTimes)
        //    {
        //        serviceTime.State.Cancel(serviceTime);
        //        await Mediator.Publish(new AppointmentDeletedNotification(serviceTime.Appointment!),
        //                                cancellationToken);
        //    }
        //}

        //foreach (var contract in ActiveContracts)
        //{
        //    AppointmentPerContracts.Add(AppointmentPerContract.Create(contract.Id, command.Date, contract.ServiceTimes.Count));
        //}

        //await UnitOfWork.AppointmentPerContractRepository.AddRangeAsync(AppointmentPerContracts!);
        //await UnitOfWork.SaveChangesAsync();

        return await Task.FromResult(Unit.Value);
    }
}