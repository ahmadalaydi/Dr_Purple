using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.UserServices.Queries;

public record GetAllUserQuery(string UserName, string Password)
    : IRequest<IDataResult<UserResponse>>;