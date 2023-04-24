using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Enums;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Commands;

public record RegisterCommand(
    string? FirstName,
    string? LastName,
    string? UserName,
    string? Password,
    string? ContactNumber,
    long? AddressId,
    Gender? Gender) : IRequest<IDataResult<AuthenticationResponse>>;