namespace Dr_Purple.Application.Utility.Results;
public class Result : IResult
{
    public bool? Succsess { get; }
    public string? Message { get; }
    public string? MessageId { get; }

    public Result(bool? succsess, string? message, string? messageId)
        : this(succsess) => (Message, MessageId) = (message, messageId);

    public Result(bool? succsess) => (Succsess) = (succsess);
}