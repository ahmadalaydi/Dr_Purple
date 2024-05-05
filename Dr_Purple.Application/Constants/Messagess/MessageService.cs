namespace Dr_Purple.Application.Constants.Messagess;
internal class MessageService : IMessageService
{
    public (string Message, string MessageId) GetMessage(int messageKey)
    {
        if (Message.AllMessages.TryGetValue(messageKey, out var message))
            return message;
        return ("Unknown message", "Unknown message ID");
    }
}