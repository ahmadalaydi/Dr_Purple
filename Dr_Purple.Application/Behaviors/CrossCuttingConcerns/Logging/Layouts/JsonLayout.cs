using log4net.Core;
using log4net.Layout;
using System.Text.Json;

namespace Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Logging.Layouts;
public class JsonLayout : LayoutSkeleton
{
    public override void ActivateOptions() { }

    public override void Format(TextWriter writer, LoggingEvent loggingEvent)
    {
        //var logEvent = new SerializableLogEvent(loggingEvent);
        var json = JsonSerializer.Serialize(this, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        writer.WriteLine(json);
    }
}
