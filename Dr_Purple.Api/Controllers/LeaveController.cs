using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.LeaveServices.Commands;
using Dr_Purple.Application.Services.LeaveServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class LeaveController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateLeaveCommand(CreateLeaveCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeLeaveCommand(CreateRangeLeaveCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteLeaveCommand(DeleteLeaveCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeLeaveCommand(DeleteRangeLeaveCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateLeaveCommand(UpdateLeaveCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeLeaveCommand(UpdateRangeLeaveCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsLeaveQuery(ExistsLeaveQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllLeaveQuery(GetAllLeaveQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByLeaveQuery(GetByLeaveQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstLeaveQuery(GetFirstLeaveQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleLeaveQuery(GetSingleLeaveQuery command)
    => Ok(await Mediator!.Send(command));
}