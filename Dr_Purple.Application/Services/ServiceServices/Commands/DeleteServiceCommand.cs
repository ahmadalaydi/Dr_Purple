
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands;

public record DeleteServiceCommand(long Id) : IRequest<IResult>;