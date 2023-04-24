namespace Dr_Purple.Application.Utility.Results;
public class ErrorResult : Result
{
    public ErrorResult(string message, string messageId) : base(false, message, messageId) { }
    public ErrorResult() : base(false) { }
}
