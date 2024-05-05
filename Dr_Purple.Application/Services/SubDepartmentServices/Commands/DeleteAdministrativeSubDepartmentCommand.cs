
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands;

public record DeleteAdministrativeSubDepartmentCommand(long Id) : IRequest<IResult>;