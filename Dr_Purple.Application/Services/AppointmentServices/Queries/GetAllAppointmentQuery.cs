using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AppointmentServices.Queries;

public record GetAllAppointmentQuery(QueryOptions Options) : IRequest<IResult>;