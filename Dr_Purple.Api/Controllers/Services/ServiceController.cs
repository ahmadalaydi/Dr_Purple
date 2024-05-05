using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ServiceServices.Commands;
using Dr_Purple.Application.Services.ServiceServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Services;
[AllowAnonymous]

public class ServiceController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateServiceCommand([FromBody] CreateServiceCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteServiceCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteServiceCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateServiceCommand([FromQuery] long id, [FromBody] UpdateServiceCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllServiceQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllServiceQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstServiceQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstServiceQuery(id)));

    [HttpGet]
    [Route("ServiceTime/All")]
    public async Task<IActionResult> GetAllServiceTimeQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllServiceTimeQuery(options)));

    [HttpGet]
    [Route("ServiceTime/GetBy")]
    public async Task<IActionResult> GetByServiceTimeQuery([FromQuery] long ServiceId)
    => Ok(await Mediator!.Send(new GetByServiceTimeQuery(ServiceId)));
}