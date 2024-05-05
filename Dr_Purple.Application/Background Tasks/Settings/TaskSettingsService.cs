using Dr_Purple.Application.Utility.Background_Tasks;
using Microsoft.Extensions.Options;

namespace Dr_Purple.Application.Constants.Notification;
public class TaskSettingsService : ITaskSettingsService
{
    private readonly TaskSettings TaskSettings;

    public TaskSettingsService(IOptions<TaskSettings>? TaskSettingsOptions)
        => TaskSettings = TaskSettingsOptions!.Value;

    public int GetTimeSlotGenerateDays() => TaskSettings.TimeSlotGenerateDays;
}