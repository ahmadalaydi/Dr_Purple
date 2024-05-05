namespace Dr_Purple.Application.Constants.Notification;
public record NotificationSettings
{
    public static string SectionName { get; } = "NotificationSettings";
    public string SenderId { get; init; } = null!;
    public string Key { get; init; } = null!;
}