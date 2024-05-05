using Dr_Purple.Application.DTO;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Commands;

public record UpdateAppointmentMaterialCommand(long AppointmentId, Material Material) : IRequest<IResult>;