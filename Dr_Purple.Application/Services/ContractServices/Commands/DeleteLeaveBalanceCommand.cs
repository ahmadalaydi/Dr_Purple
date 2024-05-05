
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands;

public record DeleteLeaveBalanceCommand(long Id) : IRequest<IResult>;