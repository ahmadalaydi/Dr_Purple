using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;


namespace Dr_Purple.Application.Services.ServiceServices.Queries;

public record GetAllServiceTimeQuery(QueryOptions Options) : IRequest<IResult>;