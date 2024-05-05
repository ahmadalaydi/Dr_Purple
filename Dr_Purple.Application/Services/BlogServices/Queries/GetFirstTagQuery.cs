using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Queries;

public record GetFirstTagQuery(long Id) : IRequest<IResult>;