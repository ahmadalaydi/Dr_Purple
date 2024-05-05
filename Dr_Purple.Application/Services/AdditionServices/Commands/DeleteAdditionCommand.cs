using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Commands;

public record DeleteAdditionCommand(long Id) : IRequest<IResult>;