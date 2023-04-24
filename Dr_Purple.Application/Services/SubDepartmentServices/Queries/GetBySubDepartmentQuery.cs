using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries;

public record GetBySubDepartmentQuery(string UserName, string Password)
    : IRequest<IDataResult<SubDepartmentResponse>>;