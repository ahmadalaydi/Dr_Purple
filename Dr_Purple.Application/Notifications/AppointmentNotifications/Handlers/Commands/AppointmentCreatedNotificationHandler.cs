using Dr_Purple.Application.Constants.Notification;
using Dr_Purple.Application.Notifications.AppointmentNotifications.Commands;
using FirebaseAdmin.Messaging;
using MediatR;

namespace Dr_Purple.Application.Notifications.AppointmentNotifications.Handlers.Commands;

public class AppointmentCreatedNotificationHandler : INotificationHandler<AppointmentCreatedNotification>
{
    private readonly INotificationService NotificationService;
    public AppointmentCreatedNotificationHandler(INotificationService notificationService)
       => NotificationService = notificationService;
    public async Task Handle(AppointmentCreatedNotification notification, CancellationToken cancellationToken)
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