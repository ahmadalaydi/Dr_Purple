using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record GetFirstAppointmentMaterialQuery(long Id) : IRequest<IResult>;