using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record GetFirstAppointmentQuery(long Id) : IRequest<IResult>;