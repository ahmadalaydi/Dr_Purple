using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands;

public record UpdateForSaleMaterialCommand(string Name, string Unit, float CostPrice, float SalePrice) : IRequest<IResult>
{
    public long Id { get; init; }
}