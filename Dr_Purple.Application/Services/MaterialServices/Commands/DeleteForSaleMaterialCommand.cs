using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Commands;

public record DeleteForSaleMaterialCommand(long Id) : IRequest<IResult>;