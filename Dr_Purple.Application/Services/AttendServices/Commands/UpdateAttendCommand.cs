using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands;

public record UpdateAttendCommand(long ContractId, DateTime StartDate, DateTime EndDate) : IRequest<IResult>
{
    public long Id { get; init; }
}