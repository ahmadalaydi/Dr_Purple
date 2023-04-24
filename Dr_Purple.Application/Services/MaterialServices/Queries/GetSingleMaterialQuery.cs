using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Queries;

public record GetSingleMaterialQuery(string UserName, string Password)
    : IRequest<IDataResult<MaterialResponse>>;