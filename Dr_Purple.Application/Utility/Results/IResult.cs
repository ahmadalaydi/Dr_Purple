namespace Dr_Purple.Application.Utility.Results;
public interface IResult
{
    bool? Succsess { get; }
    string? Message { get; }
    string? MessageId { get; }
}