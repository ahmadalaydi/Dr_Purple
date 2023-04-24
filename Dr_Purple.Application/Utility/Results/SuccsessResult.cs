namespace Dr_Purple.Application.Utility.Results;
public class SuccsessResult : Result
{
    public SuccsessResult(string message, string messageId) : base(true, message, messageId) { }

    public SuccsessResult() : base(true) { }
}