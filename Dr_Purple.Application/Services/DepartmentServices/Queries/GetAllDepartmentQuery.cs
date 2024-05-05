using Dr_Purple.Application.Utility.Paging;
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Queries;

public record GetAllDepartmentQuery(QueryOptions Options) : IRequest<IResult>;