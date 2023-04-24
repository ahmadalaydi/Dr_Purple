namespace Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Logging;
public class LogDetailWithException : LogDetail
{
    public string? ExceptionMessage { get; set; }
}
