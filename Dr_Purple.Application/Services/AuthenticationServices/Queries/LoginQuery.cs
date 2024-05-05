using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AuthenticationServices.Queries;

public record LoginQuery(string UserName, string Password) : IRequest<IResult>;