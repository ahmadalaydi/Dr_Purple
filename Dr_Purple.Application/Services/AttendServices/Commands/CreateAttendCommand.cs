using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands;

public record CreateAttendCommand(
     long ContractId,
     DateTime StartDate,
     DateTime EndDate) : IRequest<IResult>;