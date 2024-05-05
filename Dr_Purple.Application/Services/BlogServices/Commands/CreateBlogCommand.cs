using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dr_Purple.Application.Services.BlogServices.Commands;

public record CreateBlogCommand(string Title, string Content) : IRequest<Utility.Results.IResult>
{
    public IFormFile? Picture { get; init; }
}