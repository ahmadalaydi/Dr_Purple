using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Queries;

public record GetFirstAdministrativeSubDepartmentQuery(long Id) : IRequest<IResult>;