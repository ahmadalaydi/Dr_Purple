using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.DepartmentServices.Commands;

public record UpdateDepartmentCommand(string Name) : IRequest<IResult>
{
    public long Id { get; init; }
}