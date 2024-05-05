using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries;

public record GetByServiceTimeQuery(long ServiceId) : IRequest<IResult>;