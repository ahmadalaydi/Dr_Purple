
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands;

public record DeleteAttendCommand(long Id) : IRequest<IResult>;