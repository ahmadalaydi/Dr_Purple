using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;


namespace Dr_Purple.Application.Services.MaterialServices.Queries;

public record GetAllForSaleMaterialQuery(QueryOptions Options) : IRequest<IResult>;