using Dr_Purple.Api.Controllers.Base;
using Dr_Purple.Application.Services.AppointmentServices.Commands;
using Dr_Purple.Application.Services.AppointmentServices.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Dr_Purple.Api.Controllers;
[AllowAnonymous]
public class AppointmentController : ApiController
{
    [HttpPost]
    [Route("Create")]
    public async Task<IActionResult> CreateAppointmentCommand(CreateAppointmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("CreateRange")]
    public async Task<IActionResult> CreateRangeAppointmentCommand(CreateRangeAppointmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Delete")]
    public async Task<IActionResult> DeleteAppointmentCommand(DeleteAppointmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("DeleteRange")]
    public async Task<IActionResult> DeleteRangeAppointmentCommand(DeleteRangeAppointmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("Update")]
    public async Task<IActionResult> UpdateAppointmentCommand(UpdateAppointmentCommand command)
        => Ok(await Mediator!.Send(command));

    [HttpPost]
    [Route("UpdateRange")]
    public async Task<IActionResult> UpdateRangeAppointmentCommand(UpdateRangeAppointmentCommand command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("Exists")]
    public async Task<IActionResult> ExistsAppointmentQuery(ExistsAppointmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetAll")]
    public async Task<IActionResult> GetAllAppointmentQuery(GetAllAppointmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetBy")]
    public async Task<IActionResult> GetByAppointmentQuery(GetByAppointmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetFirst")]
    public async Task<IActionResult> GetFirstAppointmentQuery(GetFirstAppointmentQuery command)
    => Ok(await Mediator!.Send(command));

    [HttpGet]
    [Route("GetSingle")]
    public async Task<IActionResult> GetSingleAppointmentQuery(GetSingleAppointmentQuery command)
    => Ok(await Mediator!.Send(command));
}