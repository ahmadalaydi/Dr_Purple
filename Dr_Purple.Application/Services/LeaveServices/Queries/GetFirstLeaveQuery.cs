using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Queries;

public record GetFirstLeaveQuery(long Id) : IRequest<IResult>;