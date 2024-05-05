using Microsoft.Extensions.Options;

namespace Dr_Purple.Application.Constants.Notification;
internal class NotificationService : INotificationService
{
    private readonly NotificationSettings NotificationSettings;

    public NotificationService(IOptions<NotificationSettings>? NotificationOptions)
        => NotificationSettings = NotificationOptions!.Value;

    public string GetKey() => NotificationSettings.Key;
    public string GetSenderId() => NotificationSettings.SenderId;

    public (string Title, string Body) GetNotification(int NotificationId)
    {
        if (Notifications.AllNotifications.TryGetValue(NotificationId, out var notification))
            return notification;
        return ("Unknown Title", "Unknown Body");
    }
}