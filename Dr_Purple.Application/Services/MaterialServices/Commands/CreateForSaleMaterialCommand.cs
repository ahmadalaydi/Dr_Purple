using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands;

public record CreateForSaleMaterialCommand(
    string Name,
    string Unit,
    float CostPrice,
    float SalePrice) : IRequest<IResult>;