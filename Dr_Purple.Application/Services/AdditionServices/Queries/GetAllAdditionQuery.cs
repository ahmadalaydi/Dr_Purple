using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Queries;

public record GetAllAdditionQuery(QueryOptions Options) : IRequest<IResult>;