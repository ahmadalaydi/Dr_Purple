using Dr_Purple.Application.Constants.Notification;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using FirebaseAdmin.Messaging;
using MediatR;

namespace Dr_Purple.Application.Notifications.AppointmentNotifications.Handlers.Commands;

public class AppointmentUpdatedNotificationHandler : INotificationHandler<AppointmentUpdatedNotification>
{
    private readonly INotificationService NotificationService;
    public AppointmentUpdatedNotificationHandler(INotificationService notificationService)
       => NotificationService = notificationService;
    public async Task Handle(AppointmentUpdatedNotification notification, CancellationToken cancellationToken)
    {
        var (Title, Body) = NotificationService.GetNotification(1);

        await FirebaseMessaging.DefaultInstance.SendAsync(new Message()
        {
            Notification = new Notification
            {
                Title = Title,
                Body = Body
            },
            Token = notification.FCM_Key
        }, cancellationToken);
    }
}