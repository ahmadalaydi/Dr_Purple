using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.BlogServices.Commands;
using Dr_Purple.Application.Services.BlogServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Blogs;

[AllowAnonymous]
public class BlogController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateBlogCommand([FromForm] CreateBlogCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteBlogCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteBlogCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateBlogCommand([FromQuery] long id, [FromForm] UpdateBlogCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllBlogQuery([FromQuery] QueryOptions options)
        => Ok(await Mediator!.Send(new GetAllBlogQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstBlogQuery([FromQuery] long id)
        => Ok(await Mediator!.Send(new GetFirstBlogQuery(id)));
}