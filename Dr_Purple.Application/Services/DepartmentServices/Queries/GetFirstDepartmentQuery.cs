
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Queries;

public record GetFirstDepartmentQuery(long Id) : IRequest<IResult>;