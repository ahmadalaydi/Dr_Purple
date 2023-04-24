using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.WareHouseServices.Queries;

public record GetAllWareHouseQuery(string UserName, string Password)
    : IRequest<IDataResult<WareHouseResponse>>;