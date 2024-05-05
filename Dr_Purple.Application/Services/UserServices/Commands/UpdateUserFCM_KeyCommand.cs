using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Commands;

public record UpdateUserFCM_KeyCommand(string FCM_Key) : IRequest<IResult>;