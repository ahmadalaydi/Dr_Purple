using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Queries;

public record GetAllServiceQuery(string UserName, string Password)
    : IRequest<IDataResult<ServiceResponse>>;