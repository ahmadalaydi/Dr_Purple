using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.OrderServices.Queries;

public record ExistsOrderQuery(string UserName, string Password)
    : IRequest<IDataResult<OrderResponse>>;