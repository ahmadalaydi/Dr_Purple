using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.WareHouseServices.Queries;

public record ExistsWareHouseQuery(string Name)
    : IRequest<IDataResult<bool>>;