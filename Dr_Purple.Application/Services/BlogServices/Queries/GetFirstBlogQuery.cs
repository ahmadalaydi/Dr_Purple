using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Queries;

public record GetFirstBlogQuery(long Id) : IRequest<IResult>;