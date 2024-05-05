using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Enums;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Commands;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string ContactNumber,
    Gender Gender) : IRequest<IResult>;