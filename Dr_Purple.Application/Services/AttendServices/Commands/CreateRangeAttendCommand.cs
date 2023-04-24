using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Enums;
using MediatR;

namespace Dr_Purple.Application.Services.AttendServices.Commands;

public record CreateRangeAttendCommand(
    string? FirstName,
    string? LastName,
    string? UserName,
    string? Password,
    string? ContactNumber,
    long? AddressId,
    Role? Role,
    Gender? Gender) : IRequest<IDataResult<AttendResponse>>;