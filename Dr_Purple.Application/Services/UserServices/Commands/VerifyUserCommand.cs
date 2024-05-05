using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands;

public record VerifyUserCommand(string ContactNumber) : IRequest<IResult>;