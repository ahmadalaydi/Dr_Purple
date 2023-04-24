using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Queries;

public record GetSingleAdditionQuery(string UserName, string Password)
    : IRequest<IDataResult<AdditionResponse>>;