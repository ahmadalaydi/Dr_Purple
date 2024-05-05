using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Queries;

public record GetAllJobTitleQuery(QueryOptions Options) : IRequest<IResult>;