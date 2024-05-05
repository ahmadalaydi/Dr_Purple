using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.MaterialServices.Queries;

public record GetFirstNotForSaleMaterialQuery(long Id) : IRequest<IResult>;