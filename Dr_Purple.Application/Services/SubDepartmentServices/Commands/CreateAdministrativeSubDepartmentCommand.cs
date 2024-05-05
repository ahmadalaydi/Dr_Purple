using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands;

public record CreateAdministrativeSubDepartmentCommand(long DepartmentId, string Name) : IRequest<IResult>;