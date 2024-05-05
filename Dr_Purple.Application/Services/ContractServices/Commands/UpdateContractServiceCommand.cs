using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ContractServices.Commands;

public record UpdateContractServiceCommand(long ContractId,
    long ServiceId,
    float Percent,
     DayOfWeek Day,
     string StartTime,
     string EndTime) : IRequest<IResult>
{
    public long Id { get; init; }
}