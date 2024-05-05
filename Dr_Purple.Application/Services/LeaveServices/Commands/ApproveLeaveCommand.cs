using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands;

public record ApproveLeaveCommand() : IRequest<IResult>
{
    public long Id { get; init; }
}