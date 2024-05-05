using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AuditHistoryServices.Queries;

public record GetFirstAuditHistoryQuery(long Id) : IRequest<IResult>;