using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands.Handlers;

public class CancelAppointmentCommandHandler : IRequestHandler<CancelAppointmentCommand, IResult>
{
    private readonly IMediator Mediator;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IAuthenticatedUserService AuthenticatedUserService;


    public CancelAppointmentCommandHandler(IUnitOfWork unitOfWork, IMediator mediator,IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        Mediator = mediator;
        AuthenticatedUserService = authenticatedUserService;
    }

    public async Task<IResult> Handle(CancelAppointmentCommand command, CancellationToken cancellationToken)
    {
        var appointment = await UnitOfWork.AppointmentRepository.GetFirstAsync(_ => _.Id.Equals(command.Id));
        if (appointment is null)
            return new ErrorResult(Messages.AppointmentNotFound, Messages.AppointmentNotFoundId);

        appointment.ServiceTime!.State.Cancel(appointment.ServiceTime!);

        //await Mediator.Publish(new AppointmentDeletedNotification(AuthenticatedUserService.FCM_Key), cancellationToken);
        await UnitOfWork.AppointmentRepository.DeleteAsync(appointment);

        await UnitOfWork.SaveChangesAsync();
        return new SuccsessResult(Messages.AppointmentDeleted, Messages.AppointmentDeletedId);
    }
}