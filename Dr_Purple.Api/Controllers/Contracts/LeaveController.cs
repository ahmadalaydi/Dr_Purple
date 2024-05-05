using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ContractServices.Commands;
using Dr_Purple.Application.Services.LeaveServices.Commands;
using Dr_Purple.Application.Services.LeaveServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]

public class LeaveController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateLeaveCommand([FromBody] CreateLeaveCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteLeaveCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteLeaveCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateLeaveCommand([FromQuery] long id, [FromBody] UpdateLeaveCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));
    
    [HttpPost]
    [Route("Approve")]
    public async Task<IActionResult> ApproveLeaveCommand([FromBody] ApproveLeaveCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllLeaveQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllLeaveQuery(options)));

    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstLeaveQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstLeaveQuery(id)));
}