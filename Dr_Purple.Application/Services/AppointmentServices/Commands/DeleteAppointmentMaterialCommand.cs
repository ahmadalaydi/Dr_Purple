using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands;

public record DeleteAppointmentMaterialCommand(long AppointmentId, long MaterialId) : IRequest<IResult>;