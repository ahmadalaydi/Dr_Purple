using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Commands;

public record LogoutCommand() : IRequest<IResult>;