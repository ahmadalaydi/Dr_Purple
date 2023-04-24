using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Queries;

public record GetAllMaterialQuery(string UserName, string Password)
    : IRequest<IDataResult<MaterialResponse>>;