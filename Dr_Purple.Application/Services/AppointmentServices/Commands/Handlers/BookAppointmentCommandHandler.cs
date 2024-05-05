using Dr_Purple.Application.Constants.Messagess;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Entities.Appointments;
using Dr_Purple.Domain.Entities.Appointments.Interfaces;
using Dr_Purple.Domain.Interfaces;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands.Handlers;

public class BookAppointmentCommandHandler : IRequestHandler<BookAppointmentCommand, IResult>
{
    private readonly IMediator Mediator;
    private readonly IUnitOfWork UnitOfWork;
    private readonly IAuthenticatedUserService AuthenticatedUserService;
    public BookAppointmentCommandHandler(IUnitOfWork unitOfWork, IMediator mediator, IAuthenticatedUserService authenticatedUserService)
    {
        UnitOfWork = unitOfWork;
        Mediator = mediator;
        AuthenticatedUserService = authenticatedUserService;
    }

    public async Task<IResult> Handle(BookAppointmentCommand command, CancellationToken cancellationToken)
    {
        var serviceTime = await UnitOfWork.ServiceTimeRepository.GetFirstAsync(_ => _.Id.Equals(command.ServiceTimeId));
        if (serviceTime is null)
            return new ErrorResult(Messages.ServiceTimeNotFound, Messages.ServiceTimeNotFoundId);

        serviceTime.State.Book(serviceTime);

        var appointment = IAppointment.Create(long.Parse(AuthenticatedUserService.UserId!), command.ServiceTimeId);

        await UnitOfWork.AppointmentRepository.AddAsync(appointment);
        await UnitOfWork.ServiceTimeRepository.UpdateAsync(serviceTime);

        await UnitOfWork.SaveChangesAsync();
        //await Mediator.Publish(new AppointmentCreatedNotification(AuthenticatedUserService.FCM_Key), cancellationToken);

        return new SuccsessDataResult<Appointment>(appointment, Messages.AppointmentCreated, Messages.AppointmentCreatedId);
    }
}