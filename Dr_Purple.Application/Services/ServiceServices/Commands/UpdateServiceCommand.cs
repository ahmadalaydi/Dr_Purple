using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.ServiceServices.Commands;

public record UpdateServiceCommand(long SubDepartmentId, string Name, float Price, string Duration, string Description) : IRequest<IResult>
{
    public long Id { get; init; }
}