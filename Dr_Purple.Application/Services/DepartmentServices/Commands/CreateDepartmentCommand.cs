using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Commands;

public record CreateDepartmentCommand(string Name) : IRequest<IResult>;