using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands;

public record UpdateTagCommand(string Name) : IRequest<IResult>
{
    public long Id { get; init; }
}