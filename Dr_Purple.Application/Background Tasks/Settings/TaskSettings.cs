namespace Dr_Purple.Application.Utility.Background_Tasks;
public record TaskSettings
{
    public static string SectionName { get; } = "TaskSettings";
    public int TimeSlotGenerateDays { get; init; }
}