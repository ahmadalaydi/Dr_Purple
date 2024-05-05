using Dr_Purple.Application.Utility.Results;
using Dr_Purple.Domain.Enums;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands;

public record UpdateUserCommand(
    string FirstName,
    string LastName,
    string UserName,
    string Email,
    string Password,
    string ContactNumber,
    string? Address,
    Gender Gender) : IRequest<IResult>
{
    public long Id { get; init; }
}