using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands;

public record UpdateNotForSaleMaterialCommand(string Name, string Unit, float CostPrice) : IRequest<IResult>
{
    public long Id { get; init; }
}