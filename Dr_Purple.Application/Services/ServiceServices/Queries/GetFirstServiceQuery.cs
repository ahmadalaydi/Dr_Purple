using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries;

public record GetFirstServiceQuery(long Id) : IRequest<IResult>;