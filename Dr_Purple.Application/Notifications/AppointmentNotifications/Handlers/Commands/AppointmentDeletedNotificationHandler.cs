using Dr_Purple.Application.Constants.Notification;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using FirebaseAdmin.Messaging;
using MediatR;

namespace Dr_Purple.Application.Notifications.AppointmentNotifications.Handlers.Commands;

public class AppointmentDeletedNotificationHandler : INotificationHandler<AppointmentDeletedNotification>
{
    private readonly INotificationService NotificationService;
    public AppointmentDeletedNotificationHandler(INotificationService notificationService)
       => NotificationService = notificationService;
    public async Task Handle(AppointmentDeletedNotification notification, CancellationToken cancellationToken)
    {
        var (Title, Body) = NotificationService.GetNotification(3);

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