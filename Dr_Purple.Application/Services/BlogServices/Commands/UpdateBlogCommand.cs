using MediatR;
using Microsoft.AspNetCore.Http;

namespace Dr_Purple.Application.Services.BlogServices.Commands;

public record UpdateBlogCommand(
    string Title,
    string Content,
    bool IsPublished) : IRequest<Utility.Results.IResult>
{
    public long Id { get; init; }
    public IFormFile? Picture { get; init; }
}