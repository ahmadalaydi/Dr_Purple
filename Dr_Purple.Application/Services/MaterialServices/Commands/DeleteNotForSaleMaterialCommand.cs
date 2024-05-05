using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands;

public record DeleteNotForSaleMaterialCommand(long Id) : IRequest<IResult>;