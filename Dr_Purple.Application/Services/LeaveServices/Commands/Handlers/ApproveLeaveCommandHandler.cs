using Dr_Purple.Application.Behaviors.Aspect.Transaction;
using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Contracts;
using Dr_Purple.Domain.Entities.Services.State;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.LeaveServices.Commands.Handlers;

public class ApproveLeaveCommandHandler : IRequestHandler<ApproveLeaveCommand, IResult>
{
    private readonly IUnitOfWork UnitOfWork;
    private readonly IMediator Mediator;
    public ApproveLeaveCommandHandler(IUnitOfWork unitOfWork, IMediator mediator)
    {
        UnitOfWork = unitOfWork;
        Mediator = mediator;
    }
    [TransactionScopeAspect]
    public async Task<IResult> Handle(ApproveLeaveCommand command, CancellationToken cancellationToken)
    {
        var leave = await UnitOfWork.LeaveRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));

        if (leave is null)
            return new ErrorResult(Messages.LeaveNotFound, Messages.LeaveNotFoundId);
        leave.State.Approve(leave);

        var contract = await Task.FromResult(UnitOfWork.ContractRepository
            .GetBy(_ => _.Id.Equals(leave.ContractId))
            .Include(_ => _.ContractServices)
            .ThenInclude(_ => _.ServiceTimes
            .Where(_ => _.Date >= DateOnly.FromDateTime(leave.StartDate)
                    && _.Date <= DateOnly.FromDateTime(leave.EndDate)
                    && _.StartTime > leave.StartDate.TimeOfDay
                    && _.EndTime > leave.EndDate.TimeOfDay
                    && _.State != new LeavedServiceTimeState()
                    || _.State != new BookedServiceTimeState()))
            .ThenInclude(_ => _.Appointment)
            .AsSplitQuery().AsNoTracking().First());

        foreach (var service in contract.ContractServices)
        {
            foreach(var serviceTime in service.ServiceTimes)
            {
                serviceTime.State.Leave(serviceTime);
                //await Mediator.Publish(new AppointmentDeletedNotification(serviceTime.Appointment!.User!.FCM_Key),cancellationToken);
            }
            await UnitOfWork.ServiceTimeRepository.UpdateRangeAsync(service.ServiceTimes);
        }

        await UnitOfWork.LeaveRepository.UpdateAsync(leave);
        await UnitOfWork.SaveChangesAsync();

        return new SuccsessDataResult<Leave>(leave, Messages.LeaveUpdated, Messages.LeaveUpdatedId);
    }
}