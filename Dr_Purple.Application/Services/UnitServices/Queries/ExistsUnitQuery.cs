using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.UnitServices.Queries;

public record ExistsUnitQuery(string UserName, string Password)
    : IRequest<IDataResult<UnitResponse>>;