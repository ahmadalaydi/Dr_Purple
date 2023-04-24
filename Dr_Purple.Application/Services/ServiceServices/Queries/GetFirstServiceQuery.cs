using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries;

public record GetFirstServiceQuery(string UserName, string Password)
    : IRequest<IDataResult<ServiceResponse>>;