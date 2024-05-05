using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.LeaveServices.Commands;

public record CreateLeaveCommand(long ContractId, DateTime StartDate, DateTime EndtDate) : IRequest<IResult>;