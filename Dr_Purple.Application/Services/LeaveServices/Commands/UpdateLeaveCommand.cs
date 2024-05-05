using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands;

public record UpdateLeaveCommand(long ContractId, DateTime StartDate, DateTime EndtDate) : IRequest<IResult>
{
    public long Id { get; init; }
}