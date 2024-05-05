namespace Dr_Purple.Application.Constants.Messagess;
public interface IMessageService
{
    (string Message, string MessageId) GetMessage(int messageKey);
}
