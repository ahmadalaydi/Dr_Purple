using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Enums;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands;

public record CreateUserCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string ContactNumber,
    Role Role,
    Gender Gender) : IRequest<IResult>;