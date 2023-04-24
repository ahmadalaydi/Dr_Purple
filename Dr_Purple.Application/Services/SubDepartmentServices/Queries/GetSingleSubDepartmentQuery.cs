using Dr_Purple.Application.Mapper.Response;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries;

public record GetSingleSubDepartmentQuery(string UserName, string Password)
    : IRequest<IDataResult<SubDepartmentResponse>>;