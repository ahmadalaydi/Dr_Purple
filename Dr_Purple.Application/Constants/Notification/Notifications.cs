namespace Dr_Purple.Application.Constants.Notification;
public static class Notifications
{
    public static readonly Dictionary<int, (string Title, string Body)> AllNotifications = new()
    {
        { 1, ("Appointment Created", "Your Appointment Has Been Created") },
        { 2, ("Appointment Updated", "Your Appointment Has Been Updated") },
        { 3, ("Appointment Deleted", "Your Appointment Has Been Deleted") },
    };
}