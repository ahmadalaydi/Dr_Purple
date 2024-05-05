
using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Commands;

public record DeleteDepartmentCommand(long Id) : IRequest<IResult>;