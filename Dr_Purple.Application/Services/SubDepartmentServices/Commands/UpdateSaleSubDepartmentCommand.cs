using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.SubDepartmentServices.Commands;

public record UpdateSaleSubDepartmentCommand(long DepartmentId, string Name) : IRequest<IResult>
{
    public long Id { get; init; }
}