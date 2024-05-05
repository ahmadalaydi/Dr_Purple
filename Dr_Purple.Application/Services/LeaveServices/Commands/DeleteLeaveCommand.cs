
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands;

public record DeleteLeaveCommand(long Id) : IRequest<IResult>;