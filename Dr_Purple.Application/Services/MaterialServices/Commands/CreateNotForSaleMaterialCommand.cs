using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands;

public record CreateNotForSaleMaterialCommand(
    string Name,
    string Unit,
    float CostPrice) : IRequest<IResult>;