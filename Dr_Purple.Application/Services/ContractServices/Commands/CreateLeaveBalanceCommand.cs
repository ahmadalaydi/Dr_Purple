using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands;

public record CreateLeaveBalanceCommand(
     long ContractId,
     DateOnly StartDate,
     DateOnly EndDate,
     float Balance) : IRequest<IResult>;