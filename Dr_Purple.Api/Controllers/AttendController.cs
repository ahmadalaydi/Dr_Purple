using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AttendServices.Commands;
using Dr_Purple.Application.Services.AttendServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class AttendController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAttendCommand(CreateAttendCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeAttendCommand(CreateRangeAttendCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAttendCommand(DeleteAttendCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeAttendCommand(DeleteRangeAttendCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateAttendCommand(UpdateAttendCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeAttendCommand(UpdateRangeAttendCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsAttendQuery(ExistsAttendQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAttendQuery(GetAllAttendQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByAttendQuery(GetByAttendQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstAttendQuery(GetFirstAttendQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleAttendQuery(GetSingleAttendQuery command)
    => Ok(await Mediator!.Send(command));
}