namespace Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Logging;
public class LogDetail
{
    public string? Target { get; set; }
    public string? MethodName { get; set; }
    public List<LogParameter>? LogParameters { get; set; }
}
