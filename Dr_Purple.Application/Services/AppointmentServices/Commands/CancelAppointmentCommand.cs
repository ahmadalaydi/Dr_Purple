using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands;

public record CancelAppointmentCommand(long Id) : IRequest<IResult>;