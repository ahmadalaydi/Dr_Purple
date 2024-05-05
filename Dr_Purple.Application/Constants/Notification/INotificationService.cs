namespace Dr_Purple.Application.Constants.Notification;
public interface INotificationService
{
    string GetSenderId();
    string GetKey();
    (string Title, string Body) GetNotification(int NotificationId);
}