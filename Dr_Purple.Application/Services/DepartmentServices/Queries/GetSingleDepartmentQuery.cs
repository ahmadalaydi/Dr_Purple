using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Queries;

public record GetSingleDepartmentQuery(string UserName, string Password)
    : IRequest<IDataResult<DepartmentResponse>>;