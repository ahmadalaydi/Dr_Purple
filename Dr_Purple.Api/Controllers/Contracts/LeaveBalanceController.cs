using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.ContractServices.Commands;
using Dr_Purple.Application.Services.ContractServices.Queries;
using Dr_Purple.Application.Utility.Paging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers.Contracts;
[AllowAnonymous]

public class LeaveBalanceController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateLeaveBalanceCommand([FromBody] CreateLeaveBalanceCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpDelete]
    [Route("Delete")]
    public async Task<IActionResult> DeleteLeaveBalanceCommand([FromQuery] long id)
        => Ok(await Mediator!.Send(new DeleteLeaveBalanceCommand(id)));

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> UpdateLeaveBalanceCommand([FromQuery] long id, [FromBody] UpdateLeaveBalanceCommand command)
        => Ok(await Mediator!.Send(command with { Id = id }));

    [HttpGet]
    [Route("All")]
    public async Task<IActionResult> GetAllLeaveBalanceQuery([FromQuery] QueryOptions options)
    => Ok(await Mediator!.Send(new GetAllLeaveBalanceQuery(options)));


    [HttpGet]
    [Route("Get")]
    public async Task<IActionResult> GetFirstLeaveBalanceQuery([FromQuery] long id)
    => Ok(await Mediator!.Send(new GetFirstLeaveBalanceQuery(id)));
}