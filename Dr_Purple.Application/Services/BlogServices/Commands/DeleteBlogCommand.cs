using Dr_Purple.Application.Utility.Results;
using MediatR;

namespace Dr_Purple.Application.Services.BlogServices.Commands;

public record DeleteBlogCommand(long Id) : IRequest<IResult>;