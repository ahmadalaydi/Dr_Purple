using log4net.Core;

namespace Dr_Purple.Application.Behaviors.CrossCuttingConcerns.Logging;
[Serializable]
public class SerializableLogEvent
{
    private readonly LoggingEvent _loggingEvent;

    public SerializableLogEvent(LoggingEvent loggingEvent)
    {
        _loggingEvent = loggingEvent;
    }

    public object Message => _loggingEvent.MessageObject;
}
