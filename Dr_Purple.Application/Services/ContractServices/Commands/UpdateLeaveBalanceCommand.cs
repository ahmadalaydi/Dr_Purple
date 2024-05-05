using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands;

public record UpdateLeaveBalanceCommand(
    long ContractId,
    DateOnly StartDate,
     DateOnly EndDate,
     float Balance) : IRequest<IResult>
{
    public long Id { get; init; }
}