using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.AdditionServices.Queries;

public record GetFirstAdditionQuery(long Id) : IRequest<IResult>;