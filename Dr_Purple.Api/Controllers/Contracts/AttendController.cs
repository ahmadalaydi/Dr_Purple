using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AttendServices.Commands;
using Dr_Purple.Application.Services.AttendServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]

public class AttendController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAttendCommand([FromBody] CreateAttendCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAttendCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteAttendCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateAttendCommand([FromQuery] long id, [FromBody] UpdateAttendCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllAttendQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllAttendQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstAttendQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstAttendQuery(id)));
}