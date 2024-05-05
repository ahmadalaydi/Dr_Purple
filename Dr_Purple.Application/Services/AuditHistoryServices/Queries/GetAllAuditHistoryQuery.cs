using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AuditHistoryServices.Queries;

public record GetAllAuditHistoryQuery(QueryOptions Options) : IRequest<IResult>;