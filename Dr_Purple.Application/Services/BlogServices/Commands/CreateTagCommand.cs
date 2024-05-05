using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands;

public record CreateTagCommand(string Name) : IRequest<IResult>;