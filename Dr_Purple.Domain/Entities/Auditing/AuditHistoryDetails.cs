namespace Dr_Purple.Domain.Entities.Auditing;
public class AutoHistoryDetails
{
    public Dictionary<string, object> NewValues { get; set; } = new Dictionary<string, object>();
    public Dictionary<string, object> OldValues { get; set; } = new Dictionary<string, object>();
}