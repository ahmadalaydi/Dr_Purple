using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.UnitServices.Queries;

public record GetSingleUnitQuery(string UserName, string Password)
    : IRequest<IDataResult<UnitResponse>>;