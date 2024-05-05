using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands;

public record BookAppointmentCommand(long ServiceTimeId) : IRequest<IResult>;