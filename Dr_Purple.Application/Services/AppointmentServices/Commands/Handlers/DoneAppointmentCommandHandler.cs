using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands.Handlers;

public class DoneAppointmentCommandHandler : IRequestHandler<DoneAppointmentCommand, IResult>
{
    private readonly IMediator Mediator;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IAuthenticatedUserService AuthenticatedUserService;

    public DoneAppointmentCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        Mediator = mediator;
        AuthenticatedUserService = authenticatedUserService;
    }

    public async Task<IResult> Handle(DoneAppointmentCommand command, CancellationToken cancellationToken)
    {
        var serviceTime = await Task.FromResult(UnitOfWork.ServiceTimeRepository
            .GetBy(_ => _.Id.Equals(command.Id))
            .Include(_=>_.Appointment).AsSplitQuery().AsNoTracking()
            .Include(_ => _.Service!.SubDepartment).AsSplitQuery().AsNoTracking()
            .First());

        serviceTime.State.Done(serviceTime);

        await UnitOfWork.AppointmentPaymentRepository.AddAsync(serviceTime.Appointment!.AppointmentPayment!);
        await UnitOfWork.ServiceTimeRepository.UpdateAsync(serviceTime);
        await UnitOfWork.SaveChangesAsync();

        //await Mediator.Publish(new AppointmentDeletedNotification(AuthenticatedUserService.FCM_Key), cancellationToken);

        return new SuccsessResult(Messages.AppointmentDeleted, Messages.AppointmentDeletedId);
    }
}