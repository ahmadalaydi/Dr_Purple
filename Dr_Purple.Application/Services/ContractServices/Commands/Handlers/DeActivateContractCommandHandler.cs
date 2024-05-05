using Dr_Purple.Application.Behaviors.Aspect.Transaction;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands.Handlers;

public class DeActivateContractCommandHandler : IRequestHandler<DeActivateContractCommand, IResult>
{
    private readonly IMediator Mediator;
    private readonly IUnitOfWork UnitOfWork;
    public DeActivateContractCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        UnitOfWork = unitOfWork;
        Mediator = mediator;
    }
    [TransactionScopeAspect]
    public async Task<IResult> Handle(DeActivateContractCommand command, CancellationToken cancellationToken)
    {
        var contract = await UnitOfWork.ContractRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));
        if (contract is null)
            return new ErrorResult(Messages.ContractNotFound, Messages.ContractNotFoundId);

        foreach (var service in contract.ContractServices)
        {
            foreach (var serviceTime in service.ServiceTimes)
            {
                serviceTime.State.Cancel(serviceTime);
                await Mediator.Publish(new AppointmentDeletedNotification(serviceTime.Appointment!.User!.FCM_Key),
                                        cancellationToken);
            }
        }

        await UnitOfWork.ContractRepository.UpdateAsync(contract);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Contract>(contract, Messages.ContractUpdated, Messages.ContractUpdatedId);
    }
}