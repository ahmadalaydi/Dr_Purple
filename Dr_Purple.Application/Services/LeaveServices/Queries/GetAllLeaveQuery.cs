using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Queries;

public record GetAllLeaveQuery(QueryOptions Options) : IRequest<IResult>;