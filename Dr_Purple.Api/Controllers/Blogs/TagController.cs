using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.BlogServices.Commands;
using Dr_Purple.Application.Services.BlogServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Blogs;

[AllowAnonymous]
public class TagController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateTagCommand([FromBody] CreateTagCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteTagCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteTagCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateTagCommand([FromQuery] long id, [FromBody] UpdateTagCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllTagQuery([FromQuery] QueryOptions options)
        => Ok(await Mediator!.Send(new GetAllTagQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstTagQuery([FromQuery] long id)
        => Ok(await Mediator!.Send(new GetFirstTagQuery(id)));
}